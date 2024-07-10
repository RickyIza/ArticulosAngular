using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Galaxy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Contexts.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "DBO");
            builder.HasKey(t => t.CustomerId);
            builder.Property(t => t.FirstName).HasColumnType("nvarchar(250)");
            builder.Property(t => t.LastName).HasColumnType("nvarchar(250)");
            builder.Property(t => t.CustomerTypeId);


            builder.HasOne(uo => uo.CustomerType)
                   .WithMany(u => u.Customer)
                   .HasForeignKey(uo => uo.CustomerTypeId);
        }
    }
}
