using System.Collections.Generic;
using System.Threading.Tasks;
using MoulaClient.Contract;

namespace ServiceLocator.Interfaces
{
    public interface ICustomerServiceRequester
    {
        /// <summary>
        /// Create Customer using Using GRPC Service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool CreateCustomer(CustomerRequestVM request);

        /// <summary>
        /// Get Top Customers
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        async Task<IEnumerable<CustomerDetailVM>> GetTopCustomers(int topCount);
    }
}