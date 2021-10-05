using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayOver.Models;

namespace StayOver.Data.EntityConfig
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => new { r.ReservationId, r.ApplicationUserId });

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.HasOne(u => u.User)
            .WithMany(r => r.Reviews)
            .HasForeignKey(u => u.ApplicationUserId);
        }
    }
}
