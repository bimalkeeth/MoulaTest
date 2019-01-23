using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRepositoryFactory
    {
        T GetRepo<T,C>(T repo,CustomerDbContext context );
    }
}