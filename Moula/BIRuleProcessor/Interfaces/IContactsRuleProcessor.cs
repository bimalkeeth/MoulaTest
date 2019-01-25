using System.Collections.Generic;
using CommonContracts;

namespace BIRuleProcessor.Interfaces
{
    public interface IContacsRuleProcessor
    {
        int CreateContacts(IEnumerable<ContactsBo> contactList);
    }
}