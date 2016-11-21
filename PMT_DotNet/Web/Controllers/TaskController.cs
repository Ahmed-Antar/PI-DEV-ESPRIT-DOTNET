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

        public ActionResult AllTasks(int idProject )
        {

            var idP = Session["idProject"] as List<int>;
            
            if (idP == null)
            {
                idP = new List<int>();
            }
            
            Session["idProject"] = idP;
            var x = taskservice.DisplayTasksByProject(idProject);
            idP.Add(idProject);

            return View(x);
        }

        // GET: ReservationEvent/Create
        public ActionResult Create()
        {
            var idP = Session["idProject"] as List<int>;
            List<string> ListState = new List<string> { "ToDo", "Doing", "Done" };
            ViewBag.x = ListState.ToSelectItem();

            TaskModel taskmodel = new TaskModel();
            taskmodel.projectname= taskservice.FindNameProjectById(idP.First());
          
            return View(taskmodel);
        }


        // POST: ReservationEvent/Create
        [HttpPost]
        public ActionResult Create(TaskModel taskmodel)
        {
            var idP = Session["idProject"] as List<int>;
            taskmodel.idProject=idP.First();

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

           
           return RedirectToAction("AllTasks", new { idProject = idP.First() });
        }

        //GET: ReservationEvent/Edit/5
        public ActionResult Edit(int idProject, string description, int idUser)
        { 
            task taskToEdit = taskservice.FindTaskByPk(description);
            //TaskModel taskmodel = new TaskModel
            //{
            //    Description = taskToEdit.Description,
            //    idProject = taskToEdit.idProject,
            //    id_user = taskToEdit.id_user,
            //    DeadLine = taskToEdit.DeadLine,
            //    StartDate = taskToEdit.StartDate,
            //    state = taskToEdit.state

            //};

            return View(taskToEdit);

        }
        // POST: ReservationEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int idProject, string description, int idUser, task Task)
        {
            var idP = Session["idProject"] as List<int>;
            //task taskToEdit = taskservice.FindTaskByPk(Task.Description);
            task taskToEdit = new task { Description = Task.Description, idProject = Task.idProject, DeadLine = Task.DeadLine, StartDate = Task.StartDate, state = Task.state, id_user = Task.id_user };

            try
            {
                taskservice.Update(taskToEdit);
                //UpdateModel(taskToEdit);
            

                taskservice.commit();
                return RedirectToAction("AllTasks", new { idProject = idP.First() });


            }
            catch
            {


                return RedirectToAction("AllTasks", new { idProject = idP.First() }); 
            }


        }


        // GET: ReservationEvent/Delete/5
        public ActionResult Delete(string description)
        {
            task taskToDelete = taskservice.FindTaskByPk(description);
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
        public ActionResult Delete(string description, TaskModel taskmodel)
        {
            var idP = Session["idProject"] as List<int>;
            task taskToDelete = taskservice.FindTaskByPk(description);
            taskservice.DeleteTask(taskToDelete.Description);
            taskservice.commit();
            taskservice.Dispose();


            return RedirectToAction("AllTasks", new { idProject = idP.First() });

        }

        public ActionResult taskStat(int idProject)
       {

            string projectName = taskservice.FindNameProjectById(idProject);
            string DeadlineInfo = taskservice.projectDeadlineVerification(idProject);
           // prepare a 2d array in c#
          ArrayList header = new ArrayList { "Task State", "Number" };
          ArrayList data1 = new ArrayList { "Doing", taskservice.numberOfAccomplishTasksByProject(idProject) };
          ArrayList data2 = new ArrayList { "Done", taskservice.numberOfInProgressTasksByProject(idProject) };
          ArrayList data3 = new ArrayList { "To Do", taskservice.numberOfNotStartedTasksByProject(idProject) };
          ArrayList data = new ArrayList { header, data1, data2, data3 };
           // convert it in json
          string dataStr = JsonConvert.SerializeObject(data, Formatting.None);
           // store it in viewdata/ viewbag
          ViewBag.Data = new HtmlString(dataStr);
          ViewData["projectname"] = projectName;
          ViewData["DeadlineInfo"] = DeadlineInfo;
            return View();
        }

        public ActionResult globalView()
        {
            

            return View();
        }


}
}