using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Entities
{
    public partial class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
        }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<CustomerContacts> CustomerContacts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<States> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=CustomerDbx;User=sa;Password=Scala@1234;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Address_pk")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Street2).HasMaxLength(300);

                entity.Property(e => e.Suburb)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Address_AddressType_Id_fk");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Address_States_Id_fk");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("AddressType_pk")
                    .ForSqlServerIsClustered(false);
                
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasIndex(e => e.AddressTypeAbbr)
                    .HasName("AddressType_AddressTypeAbbr_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.AddressTypeName)
                    .HasName("AddressType_AddresType_uindex")
                    .IsUnique();

                entity.Property(e => e.AddressTypeAbbr)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.AddressTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("ContactType_pk")
                    .ForSqlServerIsClustered(false);
                
                entity.Property(e => e.Id).ValueGeneratedNever();
                
                entity.HasIndex(e => e.ContactTypeAbbr)
                    .HasName("ContactType_ContactTypeAbbr_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.ContactTypeName)
                    .HasName("ContactType_ContactType_uindex")
                    .IsUnique();

                entity.Property(e => e.ContactTypeAbbr)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ContactTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Contacts_pk")
                    .ForSqlServerIsClustered(false);
                
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .HasConstraintName("Contacts_ContactType_Id_fk");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("CudtomerAddress_pk")
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.CustomerId, e.AddressId })
                    .HasName("CudtomerAddress_CustomerId_AddressId_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("CudtomerAddress_Address_Id_fk");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("CudtomerAddress_Customers_Id_fk");
            });

            modelBuilder.Entity<CustomerContacts>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("CustomerContacts_pk")
                    .ForSqlServerIsClustered(false);
                
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => new { e.CustomerId, e.ContactId })
                    .HasName("CustomerContacts_CustomerId_ContactId_uindex")
                    .IsUnique();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("CustomerContacts_Contacts_Id_fk");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("CustomerContacts_Customers_Id_fk");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Customers_pk")
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.CustomerCode)
                    .HasName("Customers_CustomerCode_uindex")
                    .IsUnique();
                
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("States_pk")
                    .ForSqlServerIsClustered(false);
                
                entity.Property(e => e.Id).ValueGeneratedNever();
                
                entity.HasIndex(e => e.StateAbbr)
                    .HasName("States_StateAbbr_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.StateName)
                    .HasName("States_StateName_uindex")
                    .IsUnique();

                entity.Property(e => e.StateAbbr)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            Migrations.ModelBuilderExt.Seed(modelBuilder);
        }
    }
}
