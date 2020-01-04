using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfig
{
    public class ParkingConfig : IEntityTypeConfiguration<Parking>
    {
        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.Property(p => p.OpeningHour).IsRequired();
            builder.Property(p => p.ClosingHour).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(100);

            builder.Property(p => p.Spaces).IsRequired();
            builder.Property(p => p.AvailableSpaces).IsRequired();
            builder.OwnsOne(o => o.Address, address =>
            {
                address.Property(p => p.Street).HasColumnName("Street").HasMaxLength(50).IsRequired();
                address.Property(p => p.Number).HasColumnName("Number").HasMaxLength(5).IsRequired();
                address.Property(p => p.Observation).HasColumnName("Observation").HasMaxLength(150).IsRequired();
                address.Property(p => p.Latitude).HasColumnName("Latitude").HasMaxLength(10).IsRequired();
                address.Property(p => p.Longitude).HasColumnName("Longitude").HasMaxLength(10).IsRequired();
            });
        }
    }
}