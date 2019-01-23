using System;
using System.Collections.Generic;

namespace CommonContracts
{
    public class CustomerBo
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<CustomerContactsBo> Contacts { get; set; }
        public IEnumerable<CustomerAddressBo> Address { get; set; }
    }
}