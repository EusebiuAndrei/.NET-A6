using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<News> News { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<News>()
                .HasOne<Topic>(e => e.Topic)
                .WithMany(d => d.News)
                .HasForeignKey(e => e.TopicId);
        }
    }
}