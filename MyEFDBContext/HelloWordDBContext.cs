using System;
using Microsoft.EntityFrameworkCore;
using MyEFDBContext.Models;
using MyEFDBContext.Models.EntityTypeConfigurations;

namespace MyEFDBContext
{
    public class HelloWordDBContext:DbContext
    {
        //private static readonly TaggedQueryCommandInterceptor _interceptor = new TaggedQueryCommandInterceptor();
        public HelloWordDBContext():base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.AddInterceptors()
            base.OnConfiguring(optionsBuilder);
        }
        public HelloWordDBContext(DbContextOptions<HelloWordDBContext> options):base(options)
        {
            //当上下文跟踪实体时
            ChangeTracker.Tracked += ChangeTracker_Tracked;
            //当跟踪的实体更改其状态时
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            SavedChanges += HelloWordDBContext_SavedChanges;
            SavingChanges += HelloWordDBContext_SavingChanges;
            SaveChangesFailed += HelloWordDBContext_SaveChangesFailed;

        }

        private void HelloWordDBContext_SaveChangesFailed(object sender, SaveChangesFailedEventArgs e)
        {
            Console.WriteLine("SaveChangesFailed");
        }

        private void HelloWordDBContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            Console.WriteLine("SavingChanges");
        }

        private void HelloWordDBContext_SavedChanges(object sender, SavedChangesEventArgs e)
        {
            Console.WriteLine("SavedChanges");
        }

        private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            Console.WriteLine("StateChanged");
        }

        private void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            Console.WriteLine("Tracked");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
