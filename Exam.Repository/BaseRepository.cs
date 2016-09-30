using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Exam.Repository
{
    public class BaseRepository<T> : IRepository<T> where T:class
    {
        private readonly SalesDbContext _context;
        public BaseRepository()
        {
            _context = new SalesDbContext();
        }

        public int Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> GetList()
        {
            return _context.Set<T>();
        }

        public int Update(T entityOld, T entity)
        {
            var attachedEntry = _context.Entry(entityOld);
            attachedEntry.CurrentValues.SetValues(entity);
            return _context.SaveChanges();
        }
    }
}
