
using CommonConfig.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonConfig.MyDBContexts
{
    public class PlanBContext : DbContext
    {
        public PlanBContext():base()
        {
            ChangeTracker.StateChanged += UpdateTimestamps;
        }
        public PlanBContext(DbContextOptions<PlanBContext> options) : base(options)
        {
            ChangeTracker.StateChanged += UpdateTimestamps;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JerryMouseEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<JerryMouse> JerryMouses { get; set; }


        private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
           {
           
                switch (e.Entry.State)
                {
                    case EntityState.Deleted:
                      
                        Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                        break;
                    case EntityState.Modified:
                        Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                        break;
                    case EntityState.Added:
                        Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                        break;
                }
        }
    }
}
