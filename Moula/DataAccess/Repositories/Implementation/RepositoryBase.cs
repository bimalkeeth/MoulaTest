using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.Implementation;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryBase<T>:IRepositoryBase<T>,IRepositoryRoot where T:class
    {
        private bool disposed = false;
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
            return await DbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> FindAll()
        {
            return DbContext.Set<T>().AsNoTracking().ToList();
        }

        /// <summary>-----------------------------------------
        /// Get records from entity with parameter supplied
        /// </summary>----------------------------------------
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<T>> FindByParametersAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> FindByParameters(Expression<Func<T, bool>> expression)
        {
           return DbContext.Set<T>().Where(expression).AsNoTracking().ToList();
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
       
        /// <summary>----------------------------------------
        /// /Create Range of record
        /// </summary>---------------------------------------
        /// <param name="entities"></param>
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
        protected virtual void Dispose(bool disposing)  
        {
            if (disposed) return;
            if (disposing)  
            {  
                DbContext.Dispose();  
            }  
            disposed = true;
        }  
        public void Dispose()
        {
            Dispose(true);  
            GC.SuppressFinalize(this);
        }
    }
}