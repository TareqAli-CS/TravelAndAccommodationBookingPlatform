using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories
{
    public class DealRepository : IDealRepository
    {
        public readonly TravelAndAccommodationDbContext _context;
        public DealRepository(TravelAndAccommodationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Deal entity)
        {
            try
            {
                await _context.Deals.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in AddAsync: {ex.Message}", ex);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the deal: " + ex.Message);
            }
        }

        public async Task<Deal> GetDealByRoomAndDateAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            return await _context.Deals
                .FirstOrDefaultAsync(d => d.RoomId == roomId &&
                    d.StartDate <= endDate  &&
                    d.EndDate >= startDate);
        }
    }
}
