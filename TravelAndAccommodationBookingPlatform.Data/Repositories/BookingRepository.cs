using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Booking>> GetBookingsForRoomAsync(int roomId)
        {
            try
            {
                return await _context.Bookings.Where(b => b.RoomId == roomId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the bookings for the room: " + ex.Message);
                
            }
        }
        public async Task<List<Booking>> GetBookingsByUserIdAsync(int userId, int page, int pageSize)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<bool> DeleteAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                return false; // Booking not found
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Booking?> GetByIdAsync(int bookingId)
        {
            return await _context.Bookings.FindAsync(bookingId);
        }

    }
}
