using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using CommonContracts.Resources;
using DataAccess;
using DataAccess.Entities;

namespace BIRuleProcessor.Implementations
{
    public class ContactsRuleProcessor:IContactsRuleProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactsRuleProcessor(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(unitOfWork)));
            _mapper = mapper;
        }
        
        public IEnumerable<int> CreateContacts(IEnumerable<ContactsBo> contactList)
        {
            var newContacts = contactList.Select(s => new Contacts
            {
                Contact = s.Contact,
                ContactTypeId = s.ContactTypeId,
            }).ToArray();
            _unitOfWork.ContactsRepo.CreateRange(newContacts);
            _unitOfWork.SaveChanges();
            return newContacts.Select(s => s.Id);
        }
        
        public bool UpdateContacts(IEnumerable<ContactsBo> contactList)
        {
            if (contactList == null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceObject,nameof(contactList)));
            }

            var contactBos = contactList as ContactsBo[] ?? contactList.ToArray();
            if (contactBos.FirstOrDefault(s=>s.Id == 0)!=null)
            {
                throw new DataException(string.Format(BusinessRuleResource.Error_InstanceId,"Id"));
            }
            var contactUpdateList= contactBos.Select(e => new Contacts
            {
                Id = e.Id,
                Contact = e.Contact,
                ContactTypeId = e.ContactTypeId
            });
            _unitOfWork.ContactsRepo.UpdateRange(contactUpdateList);
            _unitOfWork.SaveChanges();
            return true;
        }
        public ContactsBo GetContactWithDetailById(int id)
        {
            var data = _unitOfWork.ContactsRepo.GetContactsWithDetailByFilter(w => w.Id == id).FirstOrDefault();
            return _mapper.Map<Contacts, ContactsBo>(data);
        }

        public IEnumerable<ContactsBo> GetAllContactsWithDetail()
        {
            var data = _unitOfWork.ContactsRepo.GetAllContactsWithDetail();
            return _mapper.Map<IEnumerable<Contacts>, IEnumerable<ContactsBo>>(data);
        }
        
        public IEnumerable<ContactTypeBo> GetAllContactTypes()
        {
            return _mapper.Map<IEnumerable<ContactType>, IEnumerable<ContactTypeBo>>(_unitOfWork.ContactTypeRepo.FindAll());
        }
    }
}