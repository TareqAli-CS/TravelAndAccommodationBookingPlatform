using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(BookingDto bookingDto);
        Task<decimal> CalculateTotalPriceAsync(int roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<bool> CheckForBookingConflictAsync(BookingDto bookingDto);
        public bool CheckDateRangeOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2);
        Task<List<BookingDisplayDto>> GetBookingsByUserAsync(int userId, int page, int pageSize);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<BookingDto?> GetBookingByIdAsync(int bookingId);
    }
}
