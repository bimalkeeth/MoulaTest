using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICustomerAddressRepository:IRepositoryBase<CustomerAddress>
    {
        /// <summary>
        /// Get Customer Address for Array of Ids
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        IEnumerable<CustomerAddress> GetCustomerAddress(IEnumerable<int> Ids);
    }
}