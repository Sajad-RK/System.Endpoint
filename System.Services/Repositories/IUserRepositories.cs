using PagedList.Core;
using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.Linq.Expressions;
using System.Text;

namespace System.Services.Repositories
{
    public interface IUserRepositories : IBaseRepository<User>
    {
        IPagedList<User> Find(int pageIndex, int count);
    }
    public class UserRepositories : BaseRepository<User>, IUserRepositories
    {
        IUnitOfWork unitOfWork;
        public UserRepositories(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public IPagedList<User> Find(int pageIndex, int count)
        {
            return unitOfWork.Context.Set<User>().ToPagedList(pageIndex, count);
        }
    }
}
