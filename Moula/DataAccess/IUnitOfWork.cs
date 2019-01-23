using System;
namespace DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
       int SaveChanges();
    }
}