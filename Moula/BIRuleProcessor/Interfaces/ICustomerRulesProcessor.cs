using System.Collections.Generic;
using CommonContracts;

namespace BIRuleProcessor.Interfaces
{
    public interface ICustomerRulesProcessor
    {
        int CreateCustomer(CustomerBo customer);
        
        /// <summary>
        /// Get All Top Customers
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        IEnumerable<CustomerDetailBo> GetTopCustomers(int topCount);

        /// <summary>
        /// Update Customer Mail Fields
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerBo customer);
    }
}