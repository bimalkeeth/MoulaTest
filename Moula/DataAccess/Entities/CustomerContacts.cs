using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class CustomerContacts
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public bool IsPrimaryint { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
