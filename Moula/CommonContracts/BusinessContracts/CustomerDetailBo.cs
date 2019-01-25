using System;

namespace CommonContracts
{
    public class CustomerDetailBo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CustomerCode { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}