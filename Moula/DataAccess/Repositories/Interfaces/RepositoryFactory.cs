using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public class RepositoryFactory:IRepositoryFactory
    {
        public T GetRepo<T, C>(T repo, CustomerDbContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}