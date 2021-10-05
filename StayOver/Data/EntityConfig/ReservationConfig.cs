using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayOver.Models;

namespace StayOver.Data.EntityConfig
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(a => a.ReservationId);

            builder.HasOne(r => r.Visiter)
            .WithMany(au => au.Reservations)
            .HasForeignKey(r => r.VisiterId)
            .IsRequired();

            builder.HasOne(r => r.Accommodation)
            .WithMany(a => a.Reservations)
            .HasForeignKey(r => r.AccommodationId)
            .IsRequired();

            builder.HasOne(r => r.Review)
            .WithOne(a => a.Reservation)
            .HasForeignKey<Review>(r => r.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
