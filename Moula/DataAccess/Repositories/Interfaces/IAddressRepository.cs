using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IAddressRepository:IRepositoryBase<Address>
    {
        IEnumerable<Address> GetAllAddressWithDetail();
        IEnumerable<Address> GetAddressWithDetailByAddressParameter(Expression<Func<Address,bool>> expression)
    }
}