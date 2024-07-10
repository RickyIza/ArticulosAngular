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
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Option", "DBO");
            builder.HasKey(t => t.OptionId);
            builder.Property(t => t.Title).HasColumnType("nvarchar(250)");
            builder.Property(t => t.Url).HasColumnType("nvarchar(250)");
            
        }
    }
}
