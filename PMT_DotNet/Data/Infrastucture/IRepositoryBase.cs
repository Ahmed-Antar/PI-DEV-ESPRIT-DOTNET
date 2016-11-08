using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Infrastructeurs
{
    public interface IRepositoryBase<T> where T:class 
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T,bool>> condition=null , Expression<Func<T, bool>> orderBy=null );//Type Expresion lamda , Null pour 
        void DeletebyCondition(Expression<Func<T, bool>> condition);
    }
}
