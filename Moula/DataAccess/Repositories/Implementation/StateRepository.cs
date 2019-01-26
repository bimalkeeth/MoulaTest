using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StateRepository:RepositoryBase<States>,IStateRepository
    {
        public CustomerDbContext dbContext { get; }

        public StateRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public States GetState(int id)
        {
           return dbContext.States.FirstOrDefault(d => d.Id == id);
        }
        public IEnumerable<States> GetAllStates()
        {
           return dbContext.States.AsNoTracking().ToList();
        }
    }
}