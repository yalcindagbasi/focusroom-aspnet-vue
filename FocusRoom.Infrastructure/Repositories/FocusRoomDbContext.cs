using FocusRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FocusRoom.Infrastructure.Persistence
{
    public class FocusRoomDbContext : DbContext
    {
        public FocusRoomDbContext(DbContextOptions<FocusRoomDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Session>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);
        }
    }
}