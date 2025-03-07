using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces
{
    public interface IDealRepository
    {
        Task AddAsync(Deal entity);
        Task<Deal> GetDealByRoomAndDateAsync(int roomId, DateTime startDate, DateTime endDate);
    }
}
