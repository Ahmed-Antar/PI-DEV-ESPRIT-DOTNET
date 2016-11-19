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
    public class CategoryService : MyServiceGeneric<category>
    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CategoryService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }
    }
}
