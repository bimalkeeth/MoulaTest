using System;
using System.Collections.Generic;

namespace DataAccess.Modeles
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contacts>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
    }
}
