using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly TravelAndAccommodationDbContext _context;
        public RoomRepository(TravelAndAccommodationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Room entity)
        {
            try
            {
                await _context.Rooms.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in AddAsync: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(Room entity)
        {
            try
            {
                _context.Rooms.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in DeleteAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms
                        .Include(room => room.RoomImages)
                        .ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            try
            {
                var room = await _context.Rooms
                    .Include(r => r.Deals)
                    .Include(r => r.Bookings)
                    .FirstOrDefaultAsync(r => r.RoomId == id);

                if (room != null)
                {
                    await _context.Entry(room)
                        .Collection(r => r.RoomImages)
                        .LoadAsync();

                    var currentDate = DateTime.Now;
                    room.Deals = room.Deals.Where(deal =>
                        deal.StartDate <= currentDate && currentDate <= deal.EndDate)
                        .ToList();
                }

                return room;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetByIdAsync: {ex.Message}", ex);
            }
        }

        public async Task<Room> GetRoomWithDealsAsync(int id)
        {
            try
            {
                var room = await _context.Rooms
                    .Include(r => r.Deals)
                    .FirstOrDefaultAsync(r => r.RoomId == id);
                return room;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetRoomWithDealsAsync: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Room entity)
        {
            try
            {
                _context.Rooms.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in UpdateAsync: {ex.Message}", ex);
            }
        }
    }
}
