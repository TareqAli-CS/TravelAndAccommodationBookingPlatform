using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking entity);
        Task<List<Booking>> GetBookingsForRoomAsync(int roomId);
    }
}
