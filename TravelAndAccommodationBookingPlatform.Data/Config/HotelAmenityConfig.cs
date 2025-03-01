using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class HotelAmenityConfig : IEntityTypeConfiguration<HotelAmenity>
    {
        public void Configure(EntityTypeBuilder<HotelAmenity> builder)
        {
            builder.HasKey(ha => new { ha.HotelId, ha.AmenityId });
        }
    }
}
