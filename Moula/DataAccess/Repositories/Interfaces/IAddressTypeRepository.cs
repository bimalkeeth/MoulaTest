using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IAddressTypeRepository
    {
        /// <summary>
        /// Get Address Type By Id with Included address Collection
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        AddressType GetAddressTypeWithAddress(int typeId);

        /// <summary>
        /// Get All Address type with attached Address Collection
        /// </summary>
        /// <returns></returns>
        IEnumerable<AddressType> GetAllAddressTypesWithAddresses();

        /// <summary>
        /// Get Address Types with Detail Address over supplied Filter
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<AddressType> GetAddressTypesWithAddressesByFilter(Expression<Func<AddressType, bool>> expression);
    }
}