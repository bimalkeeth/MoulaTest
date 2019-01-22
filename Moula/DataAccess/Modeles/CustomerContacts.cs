using System;
using System.Collections.Generic;

namespace DataAccess.Modeles
{
    public partial class CustomerContacts
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long CustomerId { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
