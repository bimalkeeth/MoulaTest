using System.Collections.Generic;
using CommonContracts;

namespace BIRuleProcessor.Interfaces
{
    public interface IContactsRuleProcessor
    {
        /// <summary>
        /// Create Contacts
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
        /// Get contacts by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ContactsBo GetContactWithDetailById(int id);

        /// <summary>
        /// Get all contacts with detail 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContactsBo> GetAllAddressWithDetail();
        
        
    }
}