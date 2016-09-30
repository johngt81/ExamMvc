using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Exam.Repository
{
    public interface IRepository<T>
    {
        T GetById(Expression<Func<T, bool>> match);
        int Add(T entity);
        int Update(T entityOld, T entity);
        int Delete(T entity);
        IEnumerable<T> GetList();
    }
}
