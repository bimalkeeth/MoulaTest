using System.Collections.Generic;
using System.Linq;
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

        public AddressBo GetAddressWithDetailById(int id)
        {
            var data = _unitOfWork.AddressRepo.GetAddressWithDetailByAddressParameter(w => w.Id == id).FirstOrDefault();
            return Mapper.Map<Address, AddressBo>(data);
        }

        public IEnumerable<AddressBo> GetAllAddressWithDetail()
        {
            var data = _unitOfWork.AddressRepo.GetAllAddressWithDetail();
            return Mapper.Map<IEnumerable<Address>, IEnumerable<AddressBo>>(data);
        }
    }
}