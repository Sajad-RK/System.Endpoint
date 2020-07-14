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

    public class FileRepository : BaseRepository<File>, IFileRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IPagedList<File> Find(int page, int count)
        {
            return _unitOfWork.Context.Set<File>().ToPagedList(page, count);
        }
    }
}
