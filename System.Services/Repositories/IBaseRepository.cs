using Microsoft.EntityFrameworkCore.Infrastructure;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Services.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T obj);
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        IUnitOfWork unitOfWork;
        public BaseRepository(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public void Add(T obj)
        {
            unitOfWork.Context.Set<T>().Add(obj);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return unitOfWork.Context.Set<T>().AsEnumerable();
        }

        public void Update(T obj)
        {
            unitOfWork.Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            unitOfWork.Context.Set<T>().Attach(obj);
        }
    }
}
