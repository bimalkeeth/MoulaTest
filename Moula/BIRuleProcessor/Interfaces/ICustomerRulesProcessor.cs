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

        /// <summary>
        /// Create Customer Address
        /// </summary>
        /// <param name="customerAddress"></param>
        /// <returns></returns>
        IEnumerable<int> CreateCustomerAddress(IEnumerable<CustomerAddressBo> customerAddress);

        /// <summary>
        /// Update Customer Address
        /// </summary>
        /// <param name="customerAddress"></param>
        /// <returns></returns>
        bool UpdateCustomerAddress(IEnumerable<CustomerAddressBo> customerAddress);

        /// <summary>
        /// Update Customer Contacts
        /// </summary>
        /// <param name="customerContacts"></param>
        /// <returns></returns>
        bool UpdateCustomerContacts(IEnumerable<CustomerContactsBo> customerContacts);
    }
}