using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using API.Authentication;

namespace API.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<News> News { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Topic>()
            //    .HasOne<News>(t => t.News)
            //    .WithOne(nt => nt.Topic)
            //    .HasForeignKey<News>(nt => nt.TopicId);
        }
    }
}