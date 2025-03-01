using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task AddAsync(City entity);
        Task UpdateAsync(City entity);
        Task DeleteAsync(City entity);
        Task<City> GetByIdAsync(int id);
        Task<List<City>> GetTrendingDestinationsAsync();
    }
}
