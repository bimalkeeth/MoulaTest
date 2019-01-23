using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
