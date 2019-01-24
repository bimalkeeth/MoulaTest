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
        public CustomerDbContext DbContext { get; }

        public AddressRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Address> GetAllAddressWithDetail()
        {
            var result=  DbContext.Address
                .Include(d => d.AddressType)
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerAddress.Select(w=>w.Customer))
                .AsNoTracking().ToList();
            return result;
        }
        public IEnumerable<Address> GetAddressWithDetailByAddressParameter(Expression<Func<Address,bool>> expression)
        {
            var result=  DbContext.Address
                .Include(d => d.AddressType)
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerAddress.Select(w=>w.Customer))
                .Where(expression)
                .AsNoTracking().ToList();
            return result;
        }
    }
}