using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get customers with detail data by Filters
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<Customers> GetCustomerWithDetailByFilter(Expression<Func<Customers, bool>> expression);

        /// <summary>
        /// Get customers with detail most oldest top count
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        IEnumerable<Customers> GetCustomerWithDetailByWithOrder(int topCount);
    }
}