using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class ContactRepository:RepositoryBase<Contacts>,IContactRepository
    {
        public ContactRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}