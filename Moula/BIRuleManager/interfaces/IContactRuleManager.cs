using System.Collections.Generic;
using CommonContracts;

namespace BIRuleManager.interfaces
{
    public interface IContactRuleManager
    {
        /// <summary>
        /// Create contacts
        /// </summary>
        /// <param name="contactList"></param>
        /// <returns></returns>
        IEnumerable<int> CreateContacts(IEnumerable<ContactsBo> contactList);
        
        /// <summary>
        /// Update Contacts
        /// </summary>
        /// <param name="contactList"></param>
        /// <returns></returns>
        bool UpdateContacts(IEnumerable<ContactsBo> contactList);
        
        /// <summary>
        /// Get contact with Detail By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ContactsBo GetContactWithDetailById(int id);
        
        /// <summary>
        /// Get all Address with Detail
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContactsBo> GetAllContactsWithDetail();
        
        /// <summary>
        /// Get all contact Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContactTypeBo> GetAllContactTypes();
    }
}