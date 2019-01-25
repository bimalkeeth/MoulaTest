using System.Collections.Generic;
using CommonContracts;

namespace BIRuleProcessor.Interfaces
{
    public interface IAddressRuleProcessor
    {
        /// <summary>
        /// Sav Addresses or Adress
        /// </summary>
        /// <param name="addressList"></param>
        /// <returns></returns>
        int CreateAddress(IEnumerable<AddressBo> addressList);
    }
}