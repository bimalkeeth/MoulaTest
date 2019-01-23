using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class States
    {
        public States()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string StateAbbr { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
