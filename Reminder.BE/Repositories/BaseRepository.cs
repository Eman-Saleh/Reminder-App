using Reminder.DB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BE.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void DeleteByID(int id)
        {
            _context.Remove(_context.Set<T>().Find(id));
         //  return _context.SaveChanges();
        }

        public void DeleteRange(Expression<Func<T, bool>> match)
        {
            _context.RemoveRange(_context.Set<T>().Where (match ));
        }
        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var _include in includes)
                    query = query.Include(_include);

            return query.Where(match);
        }
        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null,
        //    Expression<Func<T, object>> orderBy=null, string orderByDirection = OrderBy.Ascending)
        //{

        //    IQueryable<T> query = _context.Set<T>().Where(match);
        //    if (includes != null)
        //        foreach (var _include in includes)
        //            query = query.Include(_include);

        //    if(orderBy !=null)
        //    {
        //        if (orderByDirection == OrderBy.Ascending)
        //            query=query.OrderBy(orderBy);
        //        else
        //            query = query.OrderByDescending(orderBy);
        //    }
        //    return query.ToList();
        //}
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
         //   _context.SaveChanges();
            return entity;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
       //     _context.SaveChanges();
            return entities;
        }
        public T Update (T entity)
        {
            _context.Update(entity);
            return entity;
        }

    }
   
}
