using System;
using System.Collections.Generic;

namespace DataAccess.Modeles
{
    public partial class Contacts
    {
        public Contacts()
        {
            CustomerContacts = new HashSet<CustomerContacts>();
        }

        public long Id { get; set; }
        public long ContactTypeId { get; set; }
        public string Contact { get; set; }
        public bool IsPrimary { get; set; }

        public virtual ContactType ContactType { get; set; }
        public virtual ICollection<CustomerContacts> CustomerContacts { get; set; }
    }
}
