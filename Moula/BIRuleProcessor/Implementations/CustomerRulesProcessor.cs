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
    /// <summary>
    /// This class carries out business rules only related to customer
    /// </summary>
    public class CustomerRulesProcessor:ICustomerRulesProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerRulesProcessor(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(unitOfWork)));
            _mapper = mapper;
        }
        /// <summary>
        /// Create Customer 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="DataException"></exception>
        public int CreateCustomer(CustomerBo customer)
        {
            if (customer == null)
            {
                throw new DataException(BusinessRuleResource.Error_CustomerObject);
            }
            var customerEntity = new Customers
            {
                LastName = customer.LastName,
                FirstName = customer.FirstName,
                CustomerCode = $"{customer.FirstName.ToUpper()}{customer.LastName}{customer.DateOfBirth:yyyyMMdd}"
            };
            _unitOfWork.CustomerRepo.Create(customerEntity);
            _unitOfWork.SaveChanges();
            return customerEntity.Id;
        }

        public bool UpdateCustomer(CustomerBo customer)
        {
            if (customer == null)
            {
                throw new DataException(BusinessRuleResource.Error_CustomerObject);
            }
            if (customer.Id == 0)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceId,"Id"));
            }

           var customerUpdate= _unitOfWork.CustomerRepo.FindByParameters(s => s.Id == customer.Id).FirstOrDefault();
           if (customerUpdate != null)
           {
               customerUpdate.LastName = customer.LastName;
               customerUpdate.FirstName = customer.FirstName;
               customerUpdate.DateOfBirth = customer.DateOfBirth;
               customer.CustomerCode =
                   $"{customer.FirstName.ToUpper()}{customer.LastName}{customer.DateOfBirth:yyyyMMdd}";
               _unitOfWork.CustomerRepo.Update(customerUpdate);
           }
           _unitOfWork.SaveChanges();
           return true;
        }

        public IEnumerable<int> CreateCustomerAddress(IEnumerable<CustomerAddressBo> customerAddress)
        {
           var customerAddressBos = customerAddress as CustomerAddressBo[] ?? customerAddress.ToArray();
           var customerAdd=customerAddressBos.FirstOrDefault(s => s.AddressId == 0 || s.CustomerId == 0);
           if (customerAdd != null)
           {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceAddressIdCustomerId,nameof(CustomerAddressBo))); 
           }
           var address= customerAddressBos.Select(d =>
                new CustomerAddress
                {
                    AddressId = d.AddressId,
                    CustomerId = d.CustomerId,
                    IsPrimary = d.IsPrimary

                }).ToArray();
                _unitOfWork.CustomerAddressRepo.CreateRange(address);
                _unitOfWork.SaveChanges();
            return address.Select(d=>d.Id);
        }
        
        public bool UpdateCustomerAddress(IEnumerable<CustomerAddressBo> customerAddress)
        {
            var customerAddressBos = customerAddress as CustomerAddressBo[] ?? customerAddress.ToArray();
            var customerAdd=customerAddressBos.FirstOrDefault(s => s.AddressId == 0 || s.CustomerId == 0);
            if (customerAdd != null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceAddressIdCustomerId,nameof(CustomerAddressBo))); 
            }
            var address = customerAddressBos.Select(d => d.Id).ToArray();
            var customerAddressDb=_unitOfWork.CustomerAddressRepo.GetCustomerAddress(address).ToArray();
            
            foreach (var cust in customerAddressBos)
            {
                var item = customerAddressDb.FirstOrDefault(d => d.Id == cust.Id);
                if (item == null) continue;
                item.IsPrimary = cust.IsPrimary;
                item.AddressId = cust.AddressId;
                item.CustomerId = cust.CustomerId;
            }
            _unitOfWork.CustomerAddressRepo.UpdateRange(customerAddressDb);
            _unitOfWork.SaveChanges();
            return true;
        }
        
        public IEnumerable<int> CreateCustomerContacts(IEnumerable<CustomerContactsBo> customerContacts)
        {
            var customerContactsBos = customerContacts as CustomerContactsBo[] ?? customerContacts.ToArray();
            var customerCon=customerContactsBos.FirstOrDefault(s => s.ContactId == 0 || s.CustomerId == 0);
            if (customerCon != null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceAddressIdCustomerId,nameof(CustomerAddressBo))); 
            }
            var address= customerContactsBos.Select(d =>
                new CustomerContacts
                {
                    ContactId = d.ContactId,
                    CustomerId = d.CustomerId,
                    IsPrimaryint = d.IsPrimary

                }).ToArray();
            _unitOfWork.CustomerContactsRepo.CreateRange(address);
            _unitOfWork.SaveChanges();
            return address.Select(d=>d.Id);
        }
        
        
        public bool UpdateCustomerContacts(IEnumerable<CustomerContactsBo> customerContacts)
        {
            var customerContactsBos = customerContacts as CustomerContactsBo[] ?? customerContacts.ToArray();
            var customerCon=customerContactsBos.FirstOrDefault(s => s.ContactId == 0 || s.CustomerId == 0);
            if (customerCon != null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceContactsIdCustomerId,nameof(CustomerContactsBo))); 
            }
            var address = customerContactsBos.Select(d => d.Id).ToArray();
            var customerContactDb=_unitOfWork.CustomerContactsRepo.GetCustomerContacts(address).ToArray();
            
            foreach (var cust in customerContactsBos)
            {
                var item = customerContactDb.FirstOrDefault(d => d.Id == cust.Id);
                if (item == null) continue;
                item.IsPrimaryint = cust.IsPrimary;
                item.ContactId = cust.ContactId;
                item.CustomerId = cust.CustomerId;
            }
            _unitOfWork.CustomerContactsRepo.UpdateRange(customerContactDb);
            _unitOfWork.SaveChanges();
            return true;
        }
        
        
        
        
        public IEnumerable<CustomerDetailBo> GetTopCustomers(int topCount)
        {
           var data=_unitOfWork.CustomerRepo.GetCustomerWithDetailByWithOrder(topCount);
          return _mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerDetailBo>>(data);
        }
    }
}