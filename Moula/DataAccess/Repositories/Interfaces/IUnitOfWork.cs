using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
       int SaveChanges();
       Task<int> SaveChangeAsync();
    }
}