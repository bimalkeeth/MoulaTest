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
        public CustomerDbContext DbContext { get; }

        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Customers> GetCustomerWithDetailByFilter(Expression<Func<Customers, bool>> expression)
        {
           return DbContext.Customers
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerContacts)
                .Include(s => s.CustomerAddress.Select(a => a.Address))
                .Include(s => s.CustomerContacts.Select(a => a.Contact))
                .Where(expression).AsNoTracking().ToList();

        }
        public IEnumerable<Customers> GetCustomerWithDetailByWithOrder(int topCount)
        {
            return DbContext.Customers
                .Include(s => s.CustomerAddress)
                .Include(s => s.CustomerContacts)
                .Include(s => s.CustomerAddress.Select(a => a.Address))
                .Include(s => s.CustomerContacts.Select(a => a.Contact))
                .OrderByDescending(w=>w.DateOfBirth).AsNoTracking().Take(topCount).ToList();

        }
    }
}