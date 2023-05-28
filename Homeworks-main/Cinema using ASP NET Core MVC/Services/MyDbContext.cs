using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CinemaItem> Cinemas { get; set; }
        public DbSet<SessionItem> Sessions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CinemaItem>()
        //        .HasMany(c => c.Sessions)
        //        .WithOne(e => e.Cinema)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
