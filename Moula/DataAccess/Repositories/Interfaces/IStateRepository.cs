using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStateRepository:IRepositoryBase<States>
    {
        /// <summary>
        /// Get Sate By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        States GetState(int id);
        
        /// <summary>
        /// Get All States
        /// </summary>
        /// <returns></returns>
        IEnumerable<States> GetAllStates();
    }
}