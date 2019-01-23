using System;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public class UnitOfWork:IUnitOfWork
    {
        protected bool disposed = false;
        public CustomerDbContext Context { get; }
        public UnitOfWork(CustomerDbContext context)
        {
            Context = context;
        }
        public int SaveChanges()
        {
           return Context.SaveChanges();
        }
        public async Task<int> SaveChangeAsync()
        {
            return await Context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)  
        {
            if (disposed) return;
            if (disposing)  
            {  
                Context.Dispose();  
            }  
            disposed = true;
        }  
        public void Dispose()
        {
            Dispose(true);  
            GC.SuppressFinalize(this);
        }
    }
}