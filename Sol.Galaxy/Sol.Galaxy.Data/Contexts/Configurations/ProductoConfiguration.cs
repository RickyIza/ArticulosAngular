using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Galaxy.Data.Entities;
 

namespace Sol.Galaxy.Data.Contexts.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "DBO");
            builder.HasKey(t => t.ProductId);
            builder.Property(t => t.ProductId).HasColumnName("ProductCode");
            builder.Property(t => t.ProductName).HasColumnName("ProductDescripcion");
            builder.Property(t => t.Stock).HasColumnType("int");
            builder.Property(t => t.Price).HasColumnType("decimal(12,2)");
            builder.Property(t => t.Cost).HasColumnType("decimal(12,2)");
            builder.Property(t => t.ProductName).HasColumnType("nvarchar(250)");
        }
    }
}
