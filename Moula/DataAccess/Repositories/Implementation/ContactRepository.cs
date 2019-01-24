using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ContactRepository:RepositoryBase<Contacts>,IContactRepository
    {
        public CustomerDbContext DbContext { get; }

        public ContactRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
        
       
        
        public IEnumerable<Contacts> GetAllContactsWithDetail()
        {
            var result=  DbContext.Contacts
                .Include(d => d.ContactType)
                .Include(s => s.CustomerContacts)
                .Include(s => s.CustomerContacts.Select(w=>w.Customer))
                .AsNoTracking().ToList();
            return result;
        }
        public IEnumerable<Contacts> GetContactsWithDetailByFilter(Expression<Func<Contacts,bool>> expression)
        {
            var result=  DbContext.Contacts
                .Include(d => d.ContactType)
                .Include(s => s.CustomerContacts)
                .Include(s => s.CustomerContacts.Select(w=>w.Customer))
                .Where(expression)
                .AsNoTracking().ToList();
            return result;
            
        }
    }
}