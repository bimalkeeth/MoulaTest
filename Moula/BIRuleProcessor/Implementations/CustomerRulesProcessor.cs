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

        public CustomerRulesProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(unitOfWork)));
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
            
            
            
            return null;
        }
        
        
        public IEnumerable<CustomerDetailBo> GetTopCustomers(int topCount)
        {
           var data=_unitOfWork.CustomerRepo.GetCustomerWithDetailByWithOrder(topCount);
          return Mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerDetailBo>>(data);
        }
    }
}