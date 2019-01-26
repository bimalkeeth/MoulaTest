using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICustomerContactsRepository:IRepositoryBase<CustomerContacts>
    {
        /// <summary>
        /// Get Customer Contacts for Array of Ids
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        IEnumerable<CustomerContacts> GetCustomerContacts(IEnumerable<int> Ids);
    }
}