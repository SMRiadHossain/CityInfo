using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;


namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
        
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure foreign key constraints here

            modelBuilder.Entity<PointOfInterest>()
                .HasOne(p => p.User)
                .WithMany(u => u.PointsOfInterest)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.Restrict);

            // Additional configurations for other entities and relationships

            base.OnModelCreating(modelBuilder);
        }


    }
}
