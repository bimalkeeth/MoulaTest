using Microsoft.EntityFrameworkCore;

namespace DataAccess.Modeles
{
    public partial class MoulaContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<CustomerContacts> CustomerContacts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
    }
}