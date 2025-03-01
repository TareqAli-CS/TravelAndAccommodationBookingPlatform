using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TravelAndAccommodationDbContext _context;

        public BookingRepository(TravelAndAccommodationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Booking entity)
        {
            try
            {
                await _context.Bookings.AddAsync(entity);
            }catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the booking: " + ex.Message);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the booking: " + ex.Message);
            }
        }
    }
}
