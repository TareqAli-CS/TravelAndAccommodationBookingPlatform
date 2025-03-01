using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data
{
    public class TravelAndAccommodationDbContext : DbContext
    {
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<User> Users { get; set; }

        public TravelAndAccommodationDbContext(DbContextOptions<TravelAndAccommodationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelAndAccommodationDbContext).Assembly);
        }
    }
}
