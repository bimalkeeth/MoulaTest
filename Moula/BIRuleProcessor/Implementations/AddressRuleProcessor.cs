using System.Collections.Generic;
using AutoMapper;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using DataAccess;
using DataAccess.Entities;

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
            var datalist = Mapper.Map<IEnumerable<AddressBo>, IEnumerable<Address>>(addressList);
            _unitOfWork.AddressRepo.CreateRange(datalist);
            return _unitOfWork.SaveChanges();
        }
    }
}