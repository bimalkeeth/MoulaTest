using System;
using System.Collections.Generic;

namespace DataAccess.Modeles
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
        }

        public long Id { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string Suberb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long IsPrimary { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
