using System.Reflection.Emit;
using System.Xml;
using System;
using System.Security.Principal;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<News> News { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Topic>()
                .HasOne<News>(t => t.Topic)
                .WithOne(nt => nt.News)
                .HasForeignKey<News>(nt => nt.TopicId);
        }
    }
}