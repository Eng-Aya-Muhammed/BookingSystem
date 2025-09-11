using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Price)
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.ImageUrl)
                .HasMaxLength(500);
            builder.Property(t => t.Content)
                .HasColumnType("nvarchar(max)");
        }
    }
}
