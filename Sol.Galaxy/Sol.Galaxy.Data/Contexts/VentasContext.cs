using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sol.Galaxy.Data.Contexts.Configurations;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.Entities.Base;
using Sol.Galaxy.Utils.Logged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Contexts
{
    public class VentasContext : DbContext
    {
        private readonly ILoggedService loggedService;

        public VentasContext(DbContextOptions<VentasContext> options, ILoggedService loggedService) : base(options)
        {
            this.loggedService = loggedService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new UserOptionConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //agrego los datos de auditoria
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<AuditaBase>())
            {

                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaActualiza = DateTime.Now;
                        entry.Entity.UsuarioActualiza = loggedService.UsuarioCodigo;
                        break;
                    case EntityState.Added:
                        entry.Entity.UsuarioIngresa = loggedService.UsuarioCodigo;
                        entry.Entity.FechaIngresa = DateTime.Now;
                        break;
                    default:
                        break;
                }


            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<UserOption> UserOption { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }

    }
}
