using System;
using System.Collections.Generic;
using System.Text;
using CommonConfig.Models;
using Microsoft.EntityFrameworkCore;

namespace CommonConfig.MyDBContexts
{
    public class PlanAContext : DbContext
    {
        public PlanAContext():base()
        {

        }
        public PlanAContext(DbContextOptions<PlanAContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TomCatEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TomCat> TomCat { get; set; }
        
    }
}
