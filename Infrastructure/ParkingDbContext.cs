using Domain.Entities;
using Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ParkingDbContext : DbContext
    {
        public DbSet<Parking> Parkings { get; set; }
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParkingConfig());
        }
    }
}
