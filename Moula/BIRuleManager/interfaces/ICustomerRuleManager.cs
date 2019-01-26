using CommonContracts;

namespace BIRuleManager.interfaces
{
    public interface ICustomerRuleManager
    {
        bool CreateCustomer(CustomerBo customer);
    }
}