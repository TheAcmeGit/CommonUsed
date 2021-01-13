using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommonConfig.Models
{
   public class JerryMouseEntityTypeConfiguration : IEntityTypeConfiguration<JerryMouse>
    {
        public void Configure(EntityTypeBuilder<JerryMouse> builder)
        {
            builder.ToTable("JerryMouse");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).IsRequired().HasMaxLength(20);
            builder.Property(f => f.Gender).IsRequired().HasMaxLength(20);
        }
    }
}
