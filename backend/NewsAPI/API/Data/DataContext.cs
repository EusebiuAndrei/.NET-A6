using System.Xml;
using System;
using System.Security.Principal;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<News> News { get; set; }
        public DbSet<NewsTopic> NewsTopic { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(n => n.Id).IsRequired();
            modelBuilder.Entity<NewsTopic>()
                .Property(nt => nt.Id).IsRequired();
            modelBuilder.Entity<Topic>()
                .Property(t => t.Id).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}