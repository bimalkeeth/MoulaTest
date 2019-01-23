using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class ContactTypeRepository:RepositoryBase<ContactType>,IContactTypeRepository
    {
        public ContactTypeRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}