using System;
using System.Collections.Generic;

namespace DataAccess.Modeles
{
    public partial class CustomerAddress
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
