
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonConfig.Models
{
    public class TomCatEntityTypeConfiguration : IEntityTypeConfiguration<TomCat>
    {
        public void Configure(EntityTypeBuilder<TomCat> builder)
        {
            builder.ToTable("TomCat");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).IsRequired().HasMaxLength(20);
            builder.Property(f => f.Gender).IsRequired().HasMaxLength(20);
        }
    }


}
