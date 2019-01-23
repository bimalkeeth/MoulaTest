using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class AddressTypeRepository:RepositoryBase<AddressType>,IAddressTypeRepository
    {
        public AddressTypeRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}