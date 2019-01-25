using CommonContracts;

namespace BIRuleProcessor.Interfaces
{
    public interface ICustomerRulesProcessor
    {
        int CreateAddress(CustomerBo customer);
    }
}