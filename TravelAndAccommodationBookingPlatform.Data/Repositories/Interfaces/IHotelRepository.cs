using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task AddAsync(Hotel entity);
        Task UpdateAsync(Hotel entity);
        Task DeleteAsync(Hotel entity);
        Task<List<Hotel>> GetAllHotelsWithDetailsAsync();
        Task<List<Hotel>> GetRecentlyVisitedHotelsByUserAsync(int userId);
    }
}
