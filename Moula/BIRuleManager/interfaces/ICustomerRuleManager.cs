using System.Collections.Generic;
using CommonContracts;

namespace BIRuleManager.interfaces
{
    public interface ICustomerRuleManager
    {
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool CreateCustomer(CustomerBo customer);
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerBo customer);

        /// <summary>
        /// Get Top Customers
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        IEnumerable<CustomerDetailBo> GetTopCustomers(int topCount);
    }
}