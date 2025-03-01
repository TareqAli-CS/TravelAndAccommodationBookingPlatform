using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Config
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);

            builder.Property(c => c.CityId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.PostOffice)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.ModifiedAt)
                .IsRequired(false);

            builder.HasMany(c => c.Hotels)
                .WithOne(h => h.City)
                .HasForeignKey(h => h.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.ImageUrl)
                .IsRequired(false);
        }
    }
}
