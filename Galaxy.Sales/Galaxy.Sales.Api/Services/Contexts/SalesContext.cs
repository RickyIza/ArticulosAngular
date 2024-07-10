using Galaxy.Sales.Api.Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Sales.Api.Services.Contexts
{
    public class SalesContext : DbContext
    {
        public SalesContext(
            DbContextOptions<SalesContext> options
            ) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("a00012").
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Product { get; set; }
    }
}
