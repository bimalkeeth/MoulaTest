namespace CommonContracts
{
    public class ContactsBo
    {
        public int  Id { get; set; } 
        public int ContactTypeId { get; set; }
        public string Contact { get; set; }
        public ContactTypeBo ContactType { get; set; } 
    }
}