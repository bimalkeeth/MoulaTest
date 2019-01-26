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
        IEnumerable<int> CreateAddress(IEnumerable<AddressBo> addressList);

        /// <summary>
        /// Get Address with Related Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AddressBo GetAddressWithDetailById(int id);

        /// <summary>
        /// Get all Address with Detail
        /// </summary>
        /// <returns></returns>
        IEnumerable<AddressBo> GetAllAddressWithDetail();

        /// <summary>
        /// Update Address
        /// </summary>
        /// <param name="addressList"></param>
        /// <returns></returns>
        bool UpdateAddress(IEnumerable<AddressBo> addressList);
    }
}