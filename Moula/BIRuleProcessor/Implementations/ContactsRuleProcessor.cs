using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using DataAccess;
using DataAccess.Entities;

namespace BIRuleProcessor.Implementations
{
    public class ContactsRuleProcessor:IContactsRuleProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactsRuleProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public int CreateContacts(IEnumerable<ContactsBo> contactList)
        {
            var datalist = Mapper.Map<IEnumerable<ContactsBo>, IEnumerable<Contacts>>(contactList);
            _unitOfWork.ContactsRepo.CreateRange(datalist);
           return  _unitOfWork.SaveChanges();
        }
        
        public ContactsBo GetContactWithDetailById(int id)
        {
            var data = _unitOfWork.ContactsRepo.GetContactsWithDetailByFilter(w => w.Id == id).FirstOrDefault();
            return Mapper.Map<Contacts, ContactsBo>(data);
        }

        public IEnumerable<ContactsBo> GetAllAddressWithDetail()
        {
            var data = _unitOfWork.ContactsRepo.GetAllContactsWithDetail();
            return Mapper.Map<IEnumerable<Contacts>, IEnumerable<ContactsBo>>(data);
        }
    }
}