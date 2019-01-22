using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Modeles
{
    public partial class MoulaContext : DbContext
    {
        public MoulaContext()
        {
        }
        public MoulaContext(DbContextOptions<MoulaContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SPIDERMAN;Database=Customers;Integrated Security=true;");
            }
        }

        
    }
}
