using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
