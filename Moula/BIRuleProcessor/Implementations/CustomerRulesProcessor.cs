using System.Collections.Generic;
using System.Data;
using AutoMapper;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using CommonContracts.Resources;
using DataAccess;
using DataAccess.Entities;

namespace BIRuleProcessor.Implementations
{
    public class CustomerRulesProcessor:ICustomerRulesProcessor
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRulesProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Create Customer 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="DataException"></exception>
        public int CreateAddress(CustomerBo customer)
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
            return _unitOfWork.SaveChanges();
        }

        public IEnumerable<CustomerDetailBo> GetTopCustomers(int topCount)
        {
           var data=_unitOfWork.CustomerRepo.GetCustomerWithDetailByWithOrder(topCount);
          return Mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerDetailBo>>(data);
        }
    }
}