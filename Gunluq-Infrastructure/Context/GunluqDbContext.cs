using Gunluq_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gunluq_Infrastructure.Context
{
    public class GunluqDbContext : DbContext
    {
        public GunluqDbContext(DbContextOptions<GunluqDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDiary> UserDiaries { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<UserEverydayWord> UserEverydayWords { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserDiaries)
                .WithOne()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserNotes)
                .WithOne()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserEverydayWords)
                .WithOne()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
