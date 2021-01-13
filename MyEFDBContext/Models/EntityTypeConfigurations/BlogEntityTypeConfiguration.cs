using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyEFDBContext.Models.EntityTypeConfigurations
{
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs")
                .HasKey(f => f.BlogId);
            builder.HasMany(f => f.Posts)
                .WithOne(f => f.Blog)
                //联机删除
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(f => f.FullName).HasComputedColumnSql("Url+'==='+Url", stored: false);
            builder.Property(f => f.Isb).HasDefaultValue(false);
            //builder.Property(f => f.Url).IsConcurrencyToken();

            //设置默认值
            builder.Property(f => f.CreateTime)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
            //builder.Property(f => f.CreateTime).HasDefaultValueSql("GETDATE()");

            //隐藏影子属性，开启跟踪查询可用
            builder.Property<int>("HideField");
            //并发标记
            builder.Property(f => f.Rowversion).IsRowVersion();

            builder.Navigation(f => f.Posts).UsePropertyAccessMode(PropertyAccessMode.Property);


        }
    }

    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts").HasKey(f => f.PostId);
        }
    }
}
