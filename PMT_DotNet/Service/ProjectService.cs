using Data.Models;
using DATA.Infrastructeurs;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectService : MyServiceGeneric<project>
    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProjectService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }


        public IEnumerable<project> ActiveProject()
        {

            DateTime now = DateTime.Now;

            return ut.getRepository<project>().GetMany(x => x.EndDate > now);

        }


        public IEnumerable<project> PassedProject()
        {

            DateTime now = DateTime.Now;

            return ut.getRepository<project>().GetMany(x => x.EndDate < now);

        }


    }
}
