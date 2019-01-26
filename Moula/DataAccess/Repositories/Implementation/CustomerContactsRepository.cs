using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class CustomerContactsRepository:RepositoryBase<CustomerContacts>,ICustomerContactsRepository
    {
        public CustomerDbContext dbContext { get; }

        public CustomerContactsRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<CustomerContacts> GetCustomerContacts(IEnumerable<int> Ids)
        {
            return  dbContext.CustomerContacts.Where(s => Ids.Contains(s.Id)).ToList();
        }
    }
}