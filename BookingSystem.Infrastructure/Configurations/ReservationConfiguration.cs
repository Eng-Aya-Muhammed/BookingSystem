using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.CustomerName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(r => r.Notes)
                .HasMaxLength(1000);
            builder.HasOne(r => r.ReservedBy)
                .WithMany()
                .HasForeignKey(r => r.ReservedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Trip)
                .WithMany()
                .HasForeignKey(r => r.TripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
