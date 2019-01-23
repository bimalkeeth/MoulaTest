using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryBase<T>:IRepositoryBase<T> where T:class
    {
        public CustomerDbContext DbContext { get; }

        public RepositoryBase(CustomerDbContext dbContext)
        {
            DbContext = dbContext;
        }
        /// <summary>-------------------------------------------
        /// Get all records for the entity
        /// </summary>------------------------------------------
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        /// <summary>-----------------------------------------
        /// Get records from entity with parameter supplied
        /// </summary>----------------------------------------
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<T>> FindByParametersAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().Where(expression).ToListAsync();
        }
        
        /// <summary>----------------------------------------
        /// Create New Record for the entity
        /// </summary>---------------------------------------
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void CreateRange(IEnumerable<T> entities)
        {
           DbContext.Set<T>().AddRange(entities);
        }
        /// <summary>---------------------------------------
        /// Update Record for the Entity
        /// </summary>--------------------------------------
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        /// <summary>--------------------------------------
        /// Update Range of Entities
        /// </summary>-------------------------------------
        /// <param name="entities"></param>
        public void UpdateRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
        }

        /// <summary>-----------------------------------------
        /// Delete record from the entity by Entity
        /// </summary>----------------------------------------
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }
        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }
    }
}