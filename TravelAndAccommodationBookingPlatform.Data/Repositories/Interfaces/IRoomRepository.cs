using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task AddAsync(Room entity);
        Task UpdateAsync(Room entity);
        Task DeleteAsync(Room entity);
        Task<Room> GetRoomWithDealsAsync(int id);
    }
}
