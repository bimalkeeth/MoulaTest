using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ContactTypeRepository:RepositoryBase<ContactType>,IContactTypeRepository
    {
        public CustomerDbContext dbContext { get; }

        public ContactTypeRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public ContactType GetContactTypeWithContacts(int typeId)
        {
            return dbContext.ContactType.Include(d => d.Contacts).FirstOrDefault(d => d.Id == typeId);
        }

        public IEnumerable<ContactType> GetAllContactTypesWithContacts()
        {
            return dbContext.ContactType.Include(s => s.Contacts).AsNoTracking().ToList();
        }
        public IEnumerable<ContactType> GetContactTypesWithContactsByFilter(Expression<Func<ContactType,bool>> expression)
        {
            return dbContext.ContactType.Include(s => s.Contacts).Where(expression).AsNoTracking().ToList();
        }
    }
}