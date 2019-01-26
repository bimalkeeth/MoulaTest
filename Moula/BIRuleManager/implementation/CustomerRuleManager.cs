using System;
using System.Data;
using System.Linq;
using AutoMapper;
using BIRuleManager.interfaces;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using CommonContracts.Resources;
using DataAccess.Entities;

namespace BIRuleManager.implementation
{
    public class CustomerRuleManager:ICustomerRuleManager
    {
        private readonly IAddressRuleProcessor _addressRuleProcessor;
        private readonly IContactsRuleProcessor _contactsRuleProcessor;
        private readonly ICustomerRulesProcessor _customerRulesProcessor;
        private readonly IMapper _mapper;

        public CustomerRuleManager(IAddressRuleProcessor addressRuleProcessor,
            IContactsRuleProcessor contactsRuleProcessor,
            ICustomerRulesProcessor customerRulesProcessor,IMapper mapper)
        {
            _addressRuleProcessor = addressRuleProcessor ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(addressRuleProcessor)));
            _contactsRuleProcessor = contactsRuleProcessor ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(contactsRuleProcessor)));
            _customerRulesProcessor = customerRulesProcessor ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(customerRulesProcessor)));
            _mapper = mapper;
        }
        public bool CreateCustomer(CustomerBo customer)
        {
            if (customer == null)
            {
                throw new EvaluateException(BusinessRuleResource.Error_CustomerObject);
            }
            var customerId = _customerRulesProcessor.CreateCustomer(customer);
            if (customerId <= 0) return false;
            var address= customer.CustomerAddress.Select(s => s.Address).ToArray();
            if (address.Any())
            {
                var addressSaved= _addressRuleProcessor.CreateAddress(address).ToArray();
                if (addressSaved.Any())
                {
                    var count = 0;
                    foreach( var customerAddress in  customer.CustomerAddress)
                    {
                        customerAddress.AddressId = addressSaved[count];
                        customerAddress.CustomerId = customerId;
                        customerAddress.IsPrimary = customerAddress.IsPrimary;
                        count++;
                    }
                }
            }
            var contacts = customer.CustomerContacts.Select(s => s.Contact).ToArray();
            if (contacts.Any()) 
            {
                var savesContacts=_contactsRuleProcessor.CreateContacts(contacts).ToArray();
                if (savesContacts.Any())
                {
                    var count = 0;
                    foreach (var customerContact in customer.CustomerContacts)
                    {
                        customerContact.ContactId = savesContacts[count];
                        customerContact.CustomerId = customerId;
                        customerContact.IsPrimary = customerContact.IsPrimary;
                        count++;
                    }
                }
            }
            return true;
        }
        public bool UpdateCustomer(CustomerBo customer)
        {
            if (customer == null)
            {
                throw new EvaluateException(BusinessRuleResource.Error_CustomerObject);
            }
            if (customer.Id == 0)
            {
                throw new EvaluateException(string.Format(BusinessRuleResource.Error_InstanceId,nameof(customer)));
            }
            var customerUpdate = _customerRulesProcessor.UpdateCustomer(customer);
            if (!customerUpdate) return false;
            
            var address= customer.CustomerAddress.Select(s => s.Address).ToArray();
            var addressEmptyId= address.FirstOrDefault(s => s.Id == 0);
            if (addressEmptyId != null)
            {
                throw new EvaluateException(string.Format(BusinessRuleResource.Error_InstanceIdFor,nameof(address),addressEmptyId.Street));
            }
            if (address.Any())
            {
                _addressRuleProcessor.UpdateAddress(address);
            }
            var contacts = customer.CustomerContacts.Select(s => s.Contact).ToArray();
            var emptyContact=contacts.FirstOrDefault(s => s.Id == 0);
            if (emptyContact != null)
            {
                throw new EvaluateException(string.Format(BusinessRuleResource.Error_InstanceIdFor,nameof(contacts),emptyContact.Contact));
            }
            if (contacts.Any()) 
            {
               _contactsRuleProcessor.UpdateContacts(contacts);
            }
            return true;
        }
        
        
        
    }
}