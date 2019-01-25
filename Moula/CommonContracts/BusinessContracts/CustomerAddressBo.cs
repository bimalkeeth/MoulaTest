namespace CommonContracts
{
    public class CustomerAddressBo
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public AddressBo Address { get; set; }
        public int CustomerId { get; set; }
        public CustomerBo Customer { get; set; }
        public bool IsPrimary { get; set; }
    }
}