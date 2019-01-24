using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class RepositoryFactory:IRepositoryFactory
    {
        public T GetRepo<T>(CustomerDbContext context)
        {
            dynamic result=null;
            if (typeof(T) == typeof(IAddressRepository))
            {
                result=new AddressRepository(context) ;
            }
            if (typeof(T) == typeof(IContactRepository))
            {
                result=new ContactRepository(context) ;
            }
            if (typeof(T) == typeof(ICustomerRepository))
            {
                result=new CustomerRepository(context) ;
            }
            if (typeof(T) == typeof(IAddressTypeRepository))
            {
                result=new AddressTypeRepository(context) ;
            }
            if (typeof(T) == typeof(IContactTypeRepository))
            {
                result=new ContactTypeRepository(context) ;
            }
            return  (T)result;
        }
    }
}