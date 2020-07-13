using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using PagedList;
using PagedList.Core;

namespace System.Services.Repositories
{
    //public class FileRepository : IBaseRepository<System.DataAccessLayer.Models.File>
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    public FileRepository(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //    public void Add(File obj)
    //    {
    //        _unitOfWork.Context.Set<File>().Add(obj);
    //    }

    //    public File Find(int Id)
    //    {
    //        return _unitOfWork.Context.Set<File>().FirstOrDefault(a => a.Id == Id);
    //    }

    //    public IEnumerable<File> Find(Expression<Func<File, bool>> predicate)
    //    {
    //        return _unitOfWork.Context.Files.Where(predicate).AsEnumerable();
    //    }

    //    public PagedList.Core.PagedList<File> FindAll(int page, int count)
    //    {
    //        return (PagedList.Core.PagedList<File>)_unitOfWork.Context.Files.ToPagedList(page, count);
    //    }

    //    public void Update(File obj)
    //    {
    //        _unitOfWork.Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    //        _unitOfWork.Context.Set<File>().Attach(obj);
    //    }
    //}
}
