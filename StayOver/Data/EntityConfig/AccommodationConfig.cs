using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayOver.Models;

namespace StayOver.Data.EntityConfig
{
    public class AccommodationConfig : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.HasKey(a => a.AccommodationId);

            builder.Property(a => a.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired();

            builder.Property(a => a.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.GuestNumber)
                .IsRequired();

            builder.HasOne(c => c.City)
            .WithMany(a => a.Accommodation)
            .HasForeignKey(c => c.CityId);

            builder.HasOne(a => a.Owner)
            .WithMany(au => au.Accommodations)
            .HasForeignKey(a => a.OwnerId)
            .HasConstraintName("OwnerAccommodation_FK");
        }
    }
}
