namespace CommonContracts
{
    public class CustomerContactsBo
    {
        public int Id { get; set; }
        public bool IsPrimary { get; set; }
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public ContactsBo Contact { get; set; }
        public CustomerBo Customer { get; set; }
    }
}