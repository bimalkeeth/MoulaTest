using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class CustomerAddressRepository:RepositoryBase<CustomerAddress>,ICustomerAddressRepository
    {
        public CustomerDbContext dbContext { get; }

        public CustomerAddressRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<CustomerAddress> GetCustomerAddress(IEnumerable<int> Ids)
        {
           return  dbContext.CustomerAddress.Where(s => Ids.Contains(s.Id)).ToList();
        }
    }
}