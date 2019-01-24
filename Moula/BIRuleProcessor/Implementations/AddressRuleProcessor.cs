using System.Collections.Generic;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using DataAccess;

namespace BIRuleProcessor.Implementations
{
    public class AddressRuleProcessor:IAddressRuleProcessor
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressRuleProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public int CreateAddress(IEnumerable<AddressBo> addressList)
        {
            
            _unitOfWork.AddressRepo.CreateRange(addressList);
        }
    }
}