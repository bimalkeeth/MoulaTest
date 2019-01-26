using System.Linq;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Migrations
{
    public static class ModelBuilderExt
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<States>().HasData(
                new States
                {
                   Id = 1,
                   StateAbbr = "WA",
                   StateName = "Western Australia",
                },
                new States
                {
                    Id = 2,
                    StateAbbr = "VIC",
                    StateName = "Victoria"
                },
                new States
                {
                    Id = 3,
                    StateAbbr = "NSW",
                    StateName = "New South Wales"
                },
                new States
                {
                    Id = 4,
                    StateAbbr = "QLD",
                    StateName = "Queensland"
                },
                new States
                {
                    Id = 5,
                    StateAbbr = "TAS",
                    StateName = "Tasmania"
                },
                new States
                {
                    Id = 6,
                    StateAbbr = "SA",
                    StateName = "South Australia"
                }
            );
            modelBuilder.Entity<ContactType>().HasData(new ContactType
                {
                    Id = 1,
                    ContactTypeAbbr = "EMAIL",
                    ContactTypeName = "Email Address"
                },
                new ContactType
                {
                    Id = 2,
                    ContactTypeAbbr = "HOMEPHONE",
                    ContactTypeName = "Home Phone"
                },
                new ContactType
                {
                    Id = 3,
                    ContactTypeAbbr = "WORKPHONE",
                    ContactTypeName = "Work Phone"
                },
                new ContactType
                {
                    Id = 4,
                    ContactTypeAbbr = "MOBILEPHONE",
                    ContactTypeName = "Mobile Phone"
                }
            );
            modelBuilder.Entity<AddressType>().HasData(new AddressType
                {
                    Id = 1,
                    AddressTypeAbbr = "HOME",
                    AddressTypeName = "Home Address"
                },
                new AddressType
                {
                  Id = 2,
                  AddressTypeAbbr = "WORK",
                  AddressTypeName = "Work Address"
                },
                new AddressType
                {
                    Id = 3,
                    AddressTypeAbbr = "POST",
                    AddressTypeName = "Postal Address"
                }
            );

         }
    }
}