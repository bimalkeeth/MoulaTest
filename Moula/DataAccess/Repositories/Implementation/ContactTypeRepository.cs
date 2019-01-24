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
        public CustomerDbContext DbContext { get; }

        public ContactTypeRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
        
        public ContactType GetContactTypeWithContacts(int typeId)
        {
            return DbContext.ContactType.Include(d => d.Contacts).FirstOrDefault(d => d.Id == typeId);
        }

        public IEnumerable<ContactType> GetAllContactTypesWithContacts()
        {
            return DbContext.ContactType.Include(s => s.Contacts).AsNoTracking().ToList();
        }
        public IEnumerable<ContactType> GetContactTypesWithContactsByFilter(Expression<Func<ContactType,bool>> expression)
        {
            return DbContext.ContactType.Include(s => s.Contacts).Where(expression).AsNoTracking().ToList();
        }
    }
}