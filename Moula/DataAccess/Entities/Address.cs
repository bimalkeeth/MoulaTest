using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
        }

        public int Id { get; set; }
        public int AddressTypeId { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string Suburb { get; set; }
        public int StateId { get; set; }
        public string Country { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual States State { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
