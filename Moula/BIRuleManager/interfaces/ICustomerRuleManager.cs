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
    }
}