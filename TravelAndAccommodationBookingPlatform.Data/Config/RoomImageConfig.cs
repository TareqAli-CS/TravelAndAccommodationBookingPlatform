using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class RoomImageConfig : IEntityTypeConfiguration<RoomImage>
    {
        public void Configure(EntityTypeBuilder<RoomImage> builder)
        {
            builder.HasKey(ri => ri.ImageId);

            builder.Property(ri => ri.ImageId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ri => ri.ImageUrl)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
