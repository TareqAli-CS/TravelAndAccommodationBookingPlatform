using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TravelAndAccommodationDbContext _context;
        public HotelRepository(TravelAndAccommodationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Hotel entity)
        {
            try
            {
                await _context.Hotels.AddAsync(entity);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new InvalidOperationException($"Error in AddAsync: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(Hotel entity)
        {
            try
            {
                _context.Hotels.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in DeleteAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<Hotel>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Hotels
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Hotel>> GetAllHotelsWithDetailsAsync()
        {
            return await _context.Hotels
                     .Where(h => h.Rooms.Any(r => r.Deals.Any(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)))
                     .Select(h => new Hotel
                     {
                         HotelId = h.HotelId,
                         Name = h.Name,
                         StarRating = h.StarRating,
                         Owner = h.Owner,
                         Location = h.Location,
                         Description = h.Description,
                         CityId = h.CityId,
                         CreatedAt = h.CreatedAt,
                         ModifiedAt = h.ModifiedAt,
                         Rooms = h.Rooms.Where(r => r.Deals.Any(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now))
                               .Select(r => new Room
                               {
                                   RoomId = r.RoomId,
                                   AdultCapacity = r.AdultCapacity,
                                   ChildCapacity = r.ChildCapacity,
                                   DailyPrice = r.DailyPrice,
                                   HotelId = r.HotelId,
                                   RoomType = r.RoomType,
                                   Description = r.Description,
                                   CreatedAt = r.CreatedAt,
                                   ModifiedAt = r.ModifiedAt,
                                   NumberOfRooms = r.NumberOfRooms,
                                   Deals = r.Deals.Where(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now).ToList()
                               })
                               .ToList()
                     })
                     .ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels
                    .Include(h => h.HotelImages)
                    .Include(h => h.Reviews)
                    .Include(h => h.Rooms)
                    .FirstOrDefaultAsync(h => h.HotelId == id);
        }

        public async Task<List<Hotel>> GetRecentlyVisitedHotelsByUserAsync(int userId)
        {
            try
            {
                return await _context.Bookings
                    .Where(b => b.UserId == userId)
                    .OrderByDescending(b => b.CheckInDate)
                    .Select(b => b.Room.Hotel)
                    .Distinct()
                    .Take(3)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetRecentlyVisitedHotelsByUserAsync: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Hotel entity)
        {
            try
            {
                _context.Hotels.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in UpdateAsync: {ex.Message}", ex);
            }
        }
    }
}
