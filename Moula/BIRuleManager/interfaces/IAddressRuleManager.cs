using System.Collections.Generic;
using CommonContracts;

namespace BIRuleManager.interfaces
{
    public interface IAddressRuleManager
    {
        IEnumerable<int> CreateAddress(IEnumerable<AddressBo> addressList);
        bool UpdateAddress(IEnumerable<AddressBo> addressList);

        AddressBo GetAddressWithDetailById(int id);

        IEnumerable<AddressBo> GetAllAddressWithDetail();

        IEnumerable<AddressTypeBo> GetAllAddressType();

        IEnumerable<StateBo> GetAllStates();
    }
}