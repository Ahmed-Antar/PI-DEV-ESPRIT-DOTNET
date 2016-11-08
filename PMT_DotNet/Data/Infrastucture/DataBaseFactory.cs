using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Infrastructeurs
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private pmtbdContext context;

        public pmtbdContext DBcontext { get { return context; } }

        public DataBaseFactory()
        {
            this.context = new pmtbdContext();
        }

        protected override void DisposeCore()
        {
            if(DBcontext != null)
            DBcontext.Dispose();
        }
    }
}
