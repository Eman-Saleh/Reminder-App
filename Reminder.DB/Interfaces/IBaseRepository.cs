using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DB.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        T GetByID(int id);
        void DeleteByID(int id);
        void DeleteRange(Expression<Func<T, bool>> match);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
      //  IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null,
        //Expression <Func<T,object>> OrderBy=null,string orderByDirection= OrderBy.Ascending );
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entities);
    }
}
