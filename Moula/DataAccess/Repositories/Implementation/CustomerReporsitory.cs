using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CustomerRepository:RepositoryBase<Customers>,ICustomerRepository
    {
        public CustomerDbContext dbContext { get; }

        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Customers> GetCustomerWithDetailByFilter(Expression<Func<Customers, bool>> expression)
        {
           return dbContext.Customers
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerContacts)
                .Include(s => s.CustomerAddress.Select(a => a.Address))
                .Include(s => s.CustomerContacts.Select(a => a.Contact))
                .Where(expression).AsNoTracking().ToList();

        }
        public IEnumerable<Customers> GetCustomerWithDetailByWithOrder(int topCount)
        {
           var dd= dbContext.Customers.ToList();
            var data= dbContext.Customers
                .Include(s => s.CustomerAddress)
                .ThenInclude(s=>s.Address).ThenInclude(s=>s.State)
                .Include(s => s.CustomerContacts)
                .ThenInclude(s => s.Contact)
                .OrderByDescending(w=>w.DateOfBirth).AsNoTracking().Take(topCount).ToList();
            return data;
        }
    }
}