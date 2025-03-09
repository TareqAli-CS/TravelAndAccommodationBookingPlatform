using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking entity);
        Task<List<Booking>> GetBookingsForRoomAsync(int roomId);
        Task<List<Booking>> GetBookingsByUserIdAsync(int userId, int page, int pageSize);
        Task<bool> DeleteAsync(int bookingId);
        Task<Booking?> GetByIdAsync(int bookingId);
    }
}
