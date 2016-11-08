using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Infrastructeurs
{
    public class RepositoryBase<T>:IRepositoryBase<T> where T:class
    {
        private pmtbdContext _ctx;

        private IDbSet<T> dbset;

        public RepositoryBase(pmtbdContext ctx)
        {
            this._ctx = ctx;
            dbset = ctx.Set<T>();
        }
   

        public void Add(T t)
        {
            dbset.Add(t);
        }

        public void Delete(T t)
        {
            dbset.Remove(t);
        }

        public void Update(T t)
        {
            dbset.Attach(t);
            _ctx.Entry(t).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public T GetById(string id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            if (condition != null && orderBy == null)
            {
                return dbset.Where(condition);
            }
            if (orderBy != null && condition == null)
            {
                return dbset.OrderBy(orderBy);
            }
            if (orderBy != null && condition != null)
            {
                return dbset.Where(condition).OrderBy(orderBy);
            }
            return dbset;
        }

        public void DeletebyCondition(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> obj = dbset.Where(condition);

            foreach (T a in obj)
            {
                dbset.Remove(a);
            }
        }

        public void commit()
        {
            _ctx.SaveChanges();
        }
    }
}
