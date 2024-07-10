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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "DBO");
            builder.HasKey(t => t.UserId);
            builder.Property(t => t.UserName).HasColumnType("nvarchar(250)");
            builder.Property(t => t.UserPassword).HasColumnType("nvarchar(250)");
            builder.Property(t => t.UserRol).HasColumnType("nvarchar(150)");

            
        }
    }
}
