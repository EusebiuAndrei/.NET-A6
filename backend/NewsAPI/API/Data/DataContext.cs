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
        // public DbSet<NewsTopic> NewsTopic { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // modelBuilder.Entity<News>() // Starts configuring the News entity
            //     .HasOne<NewsTopic>(n => n.NewsTopic) // Specifies that the News entity includes one NewsTopic reference property
            //     .WithOne(nt => nt.News) // Configures the other end of the relationship, the NewsTopic entity,
            //     // it specifies that the NewsTopic entity includes a reference navigation property of News type
            //     .HasForeignKey<NewsTopic>(nt => nt.NewsId); // Specifies the foreign key property name

            // modelBuilder.Entity<Topic>()
            //     .HasOne<NewsTopic>(t => t.NewsTopic)
            //     .WithOne(nt => nt.Topic)
            //     .HasForeignKey<NewsTopic>(nt => nt.TopicId);

             modelBuilder.Entity<Topic>()
                .HasOne<News>(t => t.News)
                .WithOne(nt => nt.Topic)
                .HasForeignKey<News>(nt => nt.TopicId);
        }
    }
}