using System.Collections.Generic;
using BIRuleManager.interfaces;
using BIRuleProcessor.Interfaces;
using CommonContracts;

namespace BIRuleManager.implementation
{
    public class AddressRuleManager:IAddressRuleManager
    {
        private readonly IAddressRuleProcessor _ruleProcessor;

        public AddressRuleManager(IAddressRuleProcessor ruleProcessor)
        {
            _ruleProcessor = ruleProcessor;
        }
        public IEnumerable<int> CreateAddress(IEnumerable<AddressBo> addressList)
        {
           return _ruleProcessor.CreateAddress(addressList);
        }

        public bool UpdateAddress(IEnumerable<AddressBo> addressList)
        {
           return _ruleProcessor.UpdateAddress(addressList);
        }

        public AddressBo GetAddressWithDetailById(int id)
        {
           return _ruleProcessor.GetAddressWithDetailById(id);
        }

        public IEnumerable<AddressBo> GetAllAddressWithDetail()
        {
           return _ruleProcessor.GetAllAddressWithDetail();
        }

        public IEnumerable<AddressTypeBo> GetAllAddressType()
        {
            return _ruleProcessor.GetAllAddressType();
        }

        public IEnumerable<StateBo> GetAllStates()
        {
          return  _ruleProcessor.GetAllStates();
        }
    }
}