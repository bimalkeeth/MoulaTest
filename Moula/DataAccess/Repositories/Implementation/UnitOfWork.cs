using System;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IRepositoryFactory _repositoryFactory;

       protected bool disposed;
        public CustomerDbContext Context { get; }
        public UnitOfWork(CustomerDbContext context,IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            Context = context;
        }
        public ICustomerRepository CustomerRepo => _repositoryFactory.GetRepo<ICustomerRepository>(Context);
        public IAddressRepository  AddressRepo => _repositoryFactory.GetRepo<IAddressRepository>(Context);
        public IContactRepository  ContactsRepo => _repositoryFactory.GetRepo<IContactRepository>(Context);
        public IAddressTypeRepository  AddressTypeRepo => _repositoryFactory.GetRepo<IAddressTypeRepository>(Context);
        public IContactTypeRepository  ContactTypeRepo => _repositoryFactory.GetRepo<IContactTypeRepository>(Context);
        
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