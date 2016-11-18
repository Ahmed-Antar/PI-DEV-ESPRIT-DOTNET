using Data.Models;
using Domain.Entities;
using DATA.Infrastructeurs;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TaskService : MyServiceGeneric<task>
    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public TaskService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }

        public IEnumerable<task> DisplayTasksByProject(int idProject)
        {
            return ut.getRepository<task>().GetMany(x => x.idProject == idProject);
        }

        public IEnumerable<task> DisplayTasksByTeamMember(int idUser)
        {
            return ut.getRepository<task>().GetMany(x => x.id_user == idUser);
        }

        public void DeleteTask(string description, int idUser, int idProject)
        {
            ut.getRepository<task>().DeletebyCondition(x => x.Description == description && x.idProject == idProject && x.id_user == idUser);
        }

        public task FindTaskByPk(string description, int idUser, int idProject)
        {
            return ut.getRepository<task>().GetMany(x => x.Description == description && x.idProject == idProject && x.id_user == idUser).First();
        }

        public string FindNameProjectById(int idProject)
        {
            return ut.getRepository<project>().GetById(idProject).Name;
        }

        public int numberOfAccomplishTasksByProject(int idProject) {

            return ut.getRepository<task>().GetMany(x => x.idProject == idProject && x.state == "Done").Count();
        }

        public int numberOfInProgressTasksByProject(int idProject)
        {

            return ut.getRepository<task>().GetMany(x => x.idProject == idProject && x.state =="Doing").Count();
        }

        public int numberOfNotStartedTasksByProject(int idProject)
        {

            return ut.getRepository<task>().GetMany(x => x.idProject == idProject && x.state == "ToDo").Count();
        }

        public string projectDeadlineVerification (int idProject)
        {
            //DateTime startDate = (DateTime) ut.getRepository<project>().GetById(idProject).StartDate;
            DateTime endDate = (DateTime) ut.getRepository<project>().GetById(idProject).EndDate;
            DateTime Now = DateTime.Now;
            int result = DateTime.Compare(endDate,Now);
            TimeSpan t = endDate - Now;
            if (result > 0) { return "the DeadLine will be in"+ t.TotalDays+" days"; }
            else { return "the DeadLine Was passed"; }

        }

    }
}
