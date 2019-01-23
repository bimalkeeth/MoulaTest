using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class AddressType
    {
        public AddressType()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public string AddressTypeAbbr { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
