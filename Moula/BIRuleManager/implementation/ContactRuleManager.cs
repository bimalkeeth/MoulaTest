using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BIRuleManager.interfaces;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using CommonContracts.Resources;

namespace BIRuleManager.implementation
{
    public class ContactRuleManager:IContactRuleManager
    {
        protected readonly IContactsRuleProcessor _ruleProcessor;
        public ContactRuleManager(IContactsRuleProcessor ruleProcessor)
        {
            _ruleProcessor = ruleProcessor;
        }
        public IEnumerable<int> CreateContacts(IEnumerable<ContactsBo> contactList)
        {
            if (contactList == null)
            {
                throw new ValidationException(string.Format(BusinessRuleResource.Error_InstanceObject,
                    nameof(contactList)));
            }
            
            return _ruleProcessor.CreateContacts(contactList);
        }
        public bool UpdateContacts(IEnumerable<ContactsBo> contactList)
        {
            if (contactList == null)
            {
                throw new ValidationException(string.Format(BusinessRuleResource.Error_InstanceObject,
                    nameof(contactList)));
            }
           return _ruleProcessor.UpdateContacts(contactList);
        }
        public ContactsBo GetContactWithDetailById(int id)
        {
            return _ruleProcessor.GetContactWithDetailById(id);
        }

        public IEnumerable<ContactsBo> GetAllContactsWithDetail()
        {
           return _ruleProcessor.GetAllContactsWithDetail();
        }

        public IEnumerable<ContactTypeBo> GetAllContactTypes()
        {
           return  _ruleProcessor.GetAllContactTypes();
        }
    }
}