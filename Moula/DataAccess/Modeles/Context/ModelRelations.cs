using Microsoft.EntityFrameworkCore;

namespace DataAccess.Modeles
{
    public partial class MoulaContext
    {
        /// <summary>---------------------------------------------
        /// This function is building up relations for table 
        /// </summary>--------------------------------------------
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StreetOne)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StreetTwo).HasMaxLength(200);

                entity.Property(e => e.Suberb)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.HasIndex(e => e.Type)
                    .HasName("IX_ContactType")
                    .IsUnique();

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacts_ContactType");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasIndex(e => new { e.AddressId, e.CustomerId })
                    .HasName("IX_CustomerAddress")
                    .IsUnique();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Customers");
            });

            modelBuilder.Entity<CustomerContacts>(entity =>
            {
                entity.HasIndex(e => new { e.ContactId, e.CustomerId })
                    .HasName("IX_CustomerContacts")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerContacts_Contacts");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerContacts_Customers");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.CustCode)
                    .HasName("IX_Customers")
                    .IsUnique();

                entity.Property(e => e.CustCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}