using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using CommonContracts.Resources;
using DataAccess;
using DataAccess.Entities;

namespace BIRuleProcessor.Implementations
{
    public class AddressRuleProcessor:IAddressRuleProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressRuleProcessor(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(unitOfWork)));
            _mapper = mapper;
        }
        public IEnumerable<int> CreateAddress(IEnumerable<AddressBo> addressList)
        {
            var datalist = _mapper.Map<IEnumerable<AddressBo>, IEnumerable<Address>>(addressList);
            var enumerable = datalist as Address[] ?? datalist.ToArray();
            _unitOfWork.AddressRepo.CreateRange(enumerable);
            _unitOfWork.SaveChanges();
            return enumerable.ToList().Select(s => s.Id);
        }
        public bool UpdateAddress(IEnumerable<AddressBo> addressList)
        {
            if (addressList == null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(addressList)));
            }

            var addressBos = addressList as AddressBo[] ?? addressList.ToArray();
            if (addressBos.FirstOrDefault(s=>s.Id == 0)!=null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceId,"Id"));
            }
            var addressUpdateList= addressBos.Select(e => new Address
            {
                  Street = e.Street,
                  Suburb = e.Suburb,
                  Street2 = e.Street2,
                  StateId = e.StateId,
                  AddressTypeId = e.AddressTypeId,
                  Country = e.Country,
            });
            _unitOfWork.AddressRepo.UpdateRange(addressUpdateList);
            _unitOfWork.SaveChanges();
            return true;
        }
        public AddressBo GetAddressWithDetailById(int id)
        {
            var data = _unitOfWork.AddressRepo.GetAddressWithDetailByAddressParameter(w => w.Id == id).FirstOrDefault();
            return _mapper.Map<Address, AddressBo>(data);
        }

        public IEnumerable<AddressBo> GetAllAddressWithDetail()
        {
            var data = _unitOfWork.AddressRepo.GetAllAddressWithDetail();
            return _mapper.Map<IEnumerable<Address>, IEnumerable<AddressBo>>(data);
        }
    }
}