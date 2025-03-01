using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class DealConfig : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.HasKey(d => d.DealId);

            builder.Property(d => d.DealId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(d => d.RoomId)
                .IsRequired();

            builder.Property(d => d.DealPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(d => d.StartDate)
                .IsRequired();

            builder.Property(d => d.EndDate)
                .IsRequired();

            builder.HasOne(d => d.Room)
                .WithMany(r => r.Deals)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
