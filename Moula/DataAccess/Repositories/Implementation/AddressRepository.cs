using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AddressRepository:RepositoryBase<Address>,IAddressRepository
    {
        public CustomerDbContext dbContext { get; }

        public AddressRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Address> GetAllAddressWithDetail()
        {
            var result=  dbContext.Address
                .Include(d => d.AddressType)
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerAddress.Select(w=>w.Customer))
                .AsNoTracking().ToList();
            return result;
        }
        public IEnumerable<Address> GetAddressWithDetailByAddressParameter(Expression<Func<Address,bool>> expression)
        {
            var result=  dbContext.Address
                .Include(d => d.AddressType)
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerAddress.Select(w=>w.Customer))
                .Where(expression)
                .AsNoTracking().ToList();
            return result;
        }
    }
}