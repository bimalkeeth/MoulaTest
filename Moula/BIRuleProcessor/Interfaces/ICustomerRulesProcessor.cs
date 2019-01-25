using System.Collections.Generic;
using CommonContracts;

namespace BIRuleProcessor.Interfaces
{
    public interface ICustomerRulesProcessor
    {
        int CreateAddress(CustomerBo customer);
        
        /// <summary>
        /// Get All Top Customers
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        IEnumerable<CustomerDetailBo> GetTopCustomers(int topCount);
    }
}