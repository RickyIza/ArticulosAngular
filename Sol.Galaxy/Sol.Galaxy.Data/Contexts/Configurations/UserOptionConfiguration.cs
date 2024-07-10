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
    public class UserOptionConfiguration : IEntityTypeConfiguration<UserOption>
    {
        public void Configure(EntityTypeBuilder<UserOption> builder)
        {
            builder.ToTable("UserOption", "DBO");
            builder.HasKey(t => t.UserOptionId);

            // Configurar la clave foránea para User
            builder.HasOne(uo => uo.User)
                   .WithMany(u => u.UserOption)
                   .HasForeignKey(uo => uo.UserId);

            // Configurar la clave foránea para Option
            builder.HasOne(uo => uo.Option)
                   .WithMany(o => o.UserOption)
                   .HasForeignKey(uo => uo.OptionId);
        }
    }
}
