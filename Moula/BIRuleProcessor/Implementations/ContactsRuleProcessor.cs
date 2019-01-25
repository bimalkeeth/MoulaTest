using System.Collections.Generic;
using AutoMapper;
using BIRuleProcessor.Interfaces;
using CommonContracts;
using DataAccess;
using DataAccess.Entities;

namespace BIRuleProcessor.Implementations
{
    public class ContactsRuleProcessor:IContacsRuleProcessor
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
    }
}