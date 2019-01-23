using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class AddressRepository:RepositoryBase<Address>,IAddressRepository
    {
        public AddressRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}