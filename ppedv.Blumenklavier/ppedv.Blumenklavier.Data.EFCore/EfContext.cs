using Microsoft.EntityFrameworkCore;
using ppedv.Blumenklavier.Model;
using System;

namespace ppedv.Blumenklavier.Data.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Blume> Blumen { get; set; }
        public DbSet<Klavier> Klaviere { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blumenklavier_dev;Trusted_Connection=true");
                          //.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Blumenklavier_dev;Trusted_Connection=true");
                          //.UseSqlServer(@"Server=.;Database=Blumenklavier_dev;Trusted_Connection=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blume>().Property(x => x.Farbe).HasMaxLength(38).IsRequired();
        }
    }
}
