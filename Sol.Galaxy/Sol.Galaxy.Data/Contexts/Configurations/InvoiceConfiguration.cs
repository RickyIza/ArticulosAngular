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
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice", "DBO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Amount).HasColumnType("decimal(12,2)");

            builder.HasOne<Customer>(t => t.Customer)
                .WithMany(x => x.Invoices).HasForeignKey(x => x.CustomerId);
        }
    }
}
