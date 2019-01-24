using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IContactRepository
    {
        /// <summary>
        /// Get all contacts with attached details
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contacts> GetAllContactsWithDetail();

        /// <summary>
        /// Get all contacts with attached details by Filter
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<Contacts> GetContactsWithDetailByFilter(Expression<Func<Contacts, bool>> expression);
    }
}