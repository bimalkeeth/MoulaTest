using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    /// <summary>----------------------------------------
    /// Base Repository for common methods
    /// </summary>---------------------------------------
    public interface IRepositoryBase<T>:IDisposable
    {
        Task<IEnumerable<T>> FindAllAsync();
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindByParametersAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindByParameters(Expression<Func<T, bool>> expression);
        
        void Create(T entity);
        void CreateRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        Task SaveAsync();
        void DeleteRange(IEnumerable<T> entities);
    }
}