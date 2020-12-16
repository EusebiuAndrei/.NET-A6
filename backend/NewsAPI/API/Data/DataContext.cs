using System.Reflection.Emit;
using System.Xml;
using System;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<News> News { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Topic>()
                .HasOne<News>(t => t.News)
                .WithOne(nt => nt.Topic)
                .HasForeignKey<News>(nt => nt.TopicId);
        }
    }
}