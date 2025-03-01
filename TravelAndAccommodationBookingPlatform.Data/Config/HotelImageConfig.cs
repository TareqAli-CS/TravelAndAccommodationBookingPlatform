using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class HotelImageConfig : IEntityTypeConfiguration<HotelImage>
    {
        public void Configure(EntityTypeBuilder<HotelImage> builder)
        {
            builder.HasKey(hi => hi.ImageId);

            builder.Property(hi => hi.ImageId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(hi => hi.ImageUrl)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
