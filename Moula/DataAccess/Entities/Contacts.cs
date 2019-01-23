using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Contacts
    {
        public Contacts()
        {
            CustomerContacts = new HashSet<CustomerContacts>();
        }

        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public string Contact { get; set; }

        public virtual ContactType ContactType { get; set; }
        public virtual ICollection<CustomerContacts> CustomerContacts { get; set; }
    }
}
