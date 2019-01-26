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
                   StateAbbr = "WA",
                   StateName = "Western Australia",
                },
                new States
                {
                    StateAbbr = "VIC",
                    StateName = "Victoria"
                },
                new States
                {
                    StateAbbr = "NSW",
                    StateName = "New South Wales"
                },
                new States
                {
                    StateAbbr = "QLD",
                    StateName = "Queensland"
                },
                new States
                {
                    StateAbbr = "TAS",
                    StateName = "Tasmania"
                },
                new States
                {
                    StateAbbr = "SA",
                    StateName = "South Australia"
                }
            );

            modelBuilder.Entity<ContactType>().HasData(new ContactType
                {
                    ContactTypeAbbr = "EMAIL",
                    ContactTypeName = "Email Address"
                },
                new ContactType
                {
                    ContactTypeAbbr = "HOMEPHONE",
                    ContactTypeName = "Home Phone"
                },
                new ContactType
                {
                    ContactTypeAbbr = "WORKPHONE",
                    ContactTypeName = "Work Phone"
                },
                new ContactType
                {
                    ContactTypeAbbr = "MOBILEPHONE",
                    ContactTypeName = "Mobile Phone"
                }
            );

            modelBuilder.Entity<AddressType>().HasData(new AddressType
                {
                    AddressTypeAbbr = "HOME",
                    AddressTypeName = "Home Address"
                },
                new AddressType
                {
                  AddressTypeAbbr = "WORK",
                  AddressTypeName = "Work Address"
                },
                new AddressType
                {
                    AddressTypeAbbr = "POST",
                    AddressTypeName = "Postal Address"
                }
            );

         }
    }
}