using System;
using System.Collections.Generic;

namespace DataAccess.Modeles
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            CustomerContacts = new HashSet<CustomerContacts>();
        }

        public long Id { get; set; }
        public string CustCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        public virtual ICollection<CustomerContacts> CustomerContacts { get; set; }
    }
}
