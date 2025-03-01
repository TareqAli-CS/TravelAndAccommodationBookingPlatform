using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class AmenityConfig :  IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.HasKey(a => a.AmenityId);

            builder.Property(a => a.AmenityId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(a => a.HotelAmenities)
                .WithOne(ha => ha.Amenity)
                .HasForeignKey(ha => ha.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
