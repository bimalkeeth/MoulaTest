using System;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
       /// <summary>
       /// Save changes for commiting changes to database
       /// </summary>
       /// <returns></returns>
       int SaveChanges();
       Task<int> SaveChangeAsync();
       ICustomerRepository CustomerRepo { get; }
       IAddressRepository  AddressRepo { get; }
       IContactRepository  ContactsRepo { get; }
       IAddressTypeRepository  AddressTypeRepo { get; }
       IContactTypeRepository  ContactTypeRepo { get; }
       
    }
}