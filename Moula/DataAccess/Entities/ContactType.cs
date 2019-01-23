using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contacts>();
        }

        public int Id { get; set; }
        public string ContactTypeName { get; set; }
        public string ContactTypeAbbr { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
    }
}
