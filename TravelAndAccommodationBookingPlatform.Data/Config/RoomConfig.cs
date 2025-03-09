using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.RoomId);

            builder.Property(r => r.RoomId)
                .IsRequired()
                .ValueGeneratedOnAdd();


            builder.Property(r => r.AdultCapacity)
                .IsRequired();

            builder.Property(r => r.ChildCapacity)
                .IsRequired();

            builder.Property(r => r.RoomType)
             .IsRequired()
             .HasConversion<string>();

            builder.Property(r => r.DailyPrice)
                .IsRequired();

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(r => r.RoomImages)
                .WithOne(ri => ri.Room)
                .HasForeignKey(ri => ri.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.ModifiedAt)
                .IsRequired(false);

            builder.Property(r => r.NumberOfRooms)
                .IsRequired();

            builder.HasMany(r => r.Bookings)
               .WithOne(b => b.Room)
               .HasForeignKey(b => b.RoomId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
