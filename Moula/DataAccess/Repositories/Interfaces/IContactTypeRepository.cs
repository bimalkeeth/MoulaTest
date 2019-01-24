using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IContactTypeRepository
    {
        /// <summary>
        /// Get Contact Type with Detail by TypeId
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        ContactType GetContactTypeWithContacts(int typeId);

        /// <summary>
        /// Get CAll Contact Type with Contacts
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContactType> GetAllContactTypesWithContacts();

        /// <summary>
        /// Get All Contact Type with Contacts by Filters
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<ContactType> GetContactTypesWithContactsByFilter(Expression<Func<ContactType, bool>> expression);
    }
}