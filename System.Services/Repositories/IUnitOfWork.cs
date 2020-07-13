using System;
using System.Collections.Generic;
using System.DataAccessLayer;
using System.Text;

namespace System.Services.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Entities Context { get; }
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        public Entities Context { get; }

        public UnitOfWork(Entities _Context)
        {
            Context = _Context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
