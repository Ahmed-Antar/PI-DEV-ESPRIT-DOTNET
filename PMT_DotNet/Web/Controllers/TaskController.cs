using Data.Models;
using Domain.Entities;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    public class TaskController : Controller
    {
        TaskService taskservice = null;
        public TaskController()
        {
            taskservice = new TaskService();
        }
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllTasks()
        {
            var x = taskservice.DisplayTasksByProject(1);
            return View(x);
        }

        // GET: ReservationEvent/Create
        public ActionResult Create(string x)
        {
            List<string> ListState = new List<string> { "ToDo", "Doing", "Done" };
            ViewBag.x = ListState.ToSelectItem();

            TaskModel taskmodel = new TaskModel();
            ViewBag.y = taskservice.FindNameProjectById(taskmodel.idProject);
            return View(taskmodel);
        }


        // POST: ReservationEvent/Create
        [HttpPost]
        public ActionResult Create(TaskModel taskmodel)
        {
            

            task taskToAdd = new task
            {
                Description=taskmodel.Description,
                idProject=taskmodel.idProject,
                id_user=taskmodel.id_user,
                DeadLine=taskmodel.DeadLine,
                StartDate=taskmodel.StartDate,
                state=taskmodel.state
            };



            taskservice.Add(taskToAdd);
            taskservice.commit();
            taskservice.Dispose();

           
            RedirectToAction("AllTasks");
            return View();
        }

        //GET: ReservationEvent/Edit/5
        public ActionResult Edit(int idProject, string description, int idUser)
        { 
            task taskToEdit = taskservice.FindTaskByPk(description, idProject,idUser);
            TaskModel taskmodel = new TaskModel
            {
                Description = taskToEdit.Description,
                idProject = taskToEdit.idProject,
                id_user = taskToEdit.id_user,
                DeadLine = taskToEdit.DeadLine,
                StartDate = taskToEdit.StartDate,
                state = taskToEdit.state

            };

            return View(taskmodel);

        }
        // POST: ReservationEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int idProject, string description, int idUser, TaskModel taskmodel)
        {
            task taskToEdit = taskservice.FindTaskByPk(description, idProject, idUser); 

            try
            {
                taskservice.Update(taskToEdit);
                UpdateModel(taskToEdit);

                taskservice.commit();
                return RedirectToAction("AllTasks");


            }
            catch
            {


                return View(taskToEdit);
            }


        }


        // GET: ReservationEvent/Delete/5
        public ActionResult Delete(int idProject, string description, int idUser)
        {
            task taskToDelete = taskservice.FindTaskByPk(description, idProject, idUser);
            if (taskToDelete == null)
            {
                return HttpNotFound();
            }
            TaskModel taskmodel = new TaskModel
            {
               Description= taskToDelete.Description,
               idProject= taskToDelete.idProject,
                id_user = taskToDelete.id_user,
                DeadLine = taskToDelete.DeadLine,
                StartDate = taskToDelete.StartDate,
                state = taskToDelete.state


            };

            return View(taskToDelete);
        }

        // POST: ReservationEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(int idProject, string description, int idUser, TaskModel taskmodel)
        {
            task taskToDelete = taskservice.FindTaskByPk(description, idProject, idUser);


            taskservice.Delete(taskToDelete);
            taskservice.commit();
            return RedirectToAction("AllTasks");



        }

        public ActionResult taskStat()
       {

            string projectName = taskservice.FindNameProjectById(1);
            string DeadlineInfo = taskservice.projectDeadlineVerification(1);
           // prepare a 2d array in c#
          ArrayList header = new ArrayList { "Task State", "Number" };
          ArrayList data1 = new ArrayList { "Doing", taskservice.numberOfAccomplishTasksByProject(1) };
          ArrayList data2 = new ArrayList { "Done", taskservice.numberOfInProgressTasksByProject(1)};
          ArrayList data3 = new ArrayList { "To Do", taskservice.numberOfNotStartedTasksByProject(1) };
          ArrayList data = new ArrayList { header, data1, data2, data3 };
           // convert it in json
          string dataStr = JsonConvert.SerializeObject(data, Formatting.None);
           // store it in viewdata/ viewbag
          ViewBag.Data = new HtmlString(dataStr);
          ViewData["projectname"] = projectName;
          ViewData["DeadlineInfo"] = DeadlineInfo;
            return View();
        }

}
}