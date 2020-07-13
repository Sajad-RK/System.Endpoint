using PagedList;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace System.Services.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);
        T Find(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T obj);
    }
}
