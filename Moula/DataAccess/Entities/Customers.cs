using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            CustomerContacts = new HashSet<CustomerContacts>();
        }

        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        public virtual ICollection<CustomerContacts> CustomerContacts { get; set; }
    }
}
