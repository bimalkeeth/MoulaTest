using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class CustomerRepository:RepositoryBase<Customers>,ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}