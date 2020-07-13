using PagedList.Core;
using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Services.Repositories
{
    public interface IFileRepository : IBaseRepository<File>
    {
        IPagedList<File> Find(int pageIndex, int count);
    }

    public class FileRepository : IFileRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(File obj)
        {
            _unitOfWork.Context.Set<File>().Add(obj);
        }
        public IEnumerable<File> GetAll()
        {
            return _unitOfWork.Context.Set<File>().AsEnumerable();
        }
        public File Find(int Id)
        {
            return _unitOfWork.Context.Set<File>().FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<File> Find(Expression<Func<File, bool>> predicate)
        {
            return _unitOfWork.Context.Set<File>().Where(predicate).AsEnumerable();
        }

        public IPagedList<File> Find(int page, int count)
        {
            return _unitOfWork.Context.Set<File>().ToPagedList(page, count);
        }

        public void Update(File obj)
        {
            _unitOfWork.Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _unitOfWork.Context.Set<File>().Attach(obj);
        }
    }
}
