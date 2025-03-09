using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly TravelAndAccommodationDbContext _context;
        public CityRepository(TravelAndAccommodationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(City entity)
        {
            try
            {
                await _context.Cities.AddAsync(entity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in AddAsync: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(City entity)
        {
            try
            {
                _context.Cities.Remove(entity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in DeleteAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<City>> GetAllAsync()
        {
            try
            {
                return await _context.Cities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetAllAsync: {ex.Message}", ex);
            }
        }

        public async Task<City> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Cities.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetByIdAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<City>> GetTrendingDestinationsAsync()
        {
            try
            {
                var trendingCityIds = await _context.Bookings
                   .Include(booking => booking.Room.Hotel)
                   .Where(booking => booking.Room.Hotel != null)
                   .GroupBy(booking => booking.Room.Hotel.CityId)
                   .OrderByDescending(group => group.Count())
                   .Take(5)
                   .Select(group => group.Key)
                   .ToListAsync();

                var trendingDestinations = await _context.Cities
                    .Where(city => trendingCityIds.Contains(city.CityId))
                    .ToListAsync();

                return trendingDestinations;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetTrendingDestinations: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(City entity)
        {
            try
            {
                _context.Cities.Update(entity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in UpdateAsync: {ex.Message}", ex);
            }
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in SaveAsync: {ex.Message}", ex);
            }
        }
    }
}
