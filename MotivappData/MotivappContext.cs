using Microsoft.EntityFrameworkCore;
using MotivappData.Models;

namespace MotivappData
{
    public class MotivappContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Milestone> Milestones { get; set; }


        public MotivappContext(DbContextOptions<MotivappContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserBuilder(modelBuilder);

            CategoryBuilder(modelBuilder);

            MilestoneBuilder(modelBuilder);
        }

        private void UserBuilder(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<User>();

            builder
                .HasKey(r => r.Id);

            builder
                .Property(prop => prop.UserName)
                .HasMaxLength(150);

            builder
                .Property(prop => prop.AvatarURL)
                .HasMaxLength(250);

            builder
                .HasMany(x => x.Milestones)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void MilestoneBuilder(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Milestone>();

            builder
                .HasKey(r => r.Id);
        }

        private void CategoryBuilder(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Category>();

            builder
                .HasKey(r => r.Id);

            builder
                .Property(prop => prop.CategoryName)
                .HasMaxLength(150);

            builder
                .Property(prop => prop.AvatarURL)
                .HasMaxLength(250);

            builder
                .HasMany(x => x.Milestones)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
