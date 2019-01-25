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
        public CustomerDbContext DbContext { get; }

        public StateRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
        public States GetState(int id)
        {
           return DbContext.States.FirstOrDefault(d => d.Id == id);
        }
        public IEnumerable<States> GetAllStates()
        {
           return DbContext.States.AsNoTracking().ToList();
        }
    }
}