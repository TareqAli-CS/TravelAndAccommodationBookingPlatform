using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IBookingService> _logger;
        public BookingService(IBookingRepository bookingRepository,
            IRoomRepository roomRepository,
            IMapper mapper,
            ILogger<IBookingService> logger)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> CreateBookingAsync(BookingDto bookingDto)
        {
            try
            {
                if (await CheckForBookingConflictAsync(bookingDto))
                {
                    _logger.LogError("Booking conflict detected. Cannot create the booking.");
                    return false;
                }
                var bookingEntity = _mapper.Map<Booking>(bookingDto);
                var totalPrice = await CalculateTotalPriceAsync(bookingEntity.RoomId, bookingEntity.CheckInDate, bookingEntity.CheckOutDate);
                bookingEntity.TotalPrice = totalPrice;

                await _bookingRepository.AddAsync(bookingEntity);

                _logger.LogInformation("Booking added successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateBookingAsync: {ex.Message}");
                return false;
            }
        }
        public async Task<decimal> CalculateTotalPriceAsync(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            try
            {
                var room = await _roomRepository.GetRoomWithDealsAsync(roomId);
                decimal pricePerNight;
                if (room != null)
                {
                    var activeDeal = room.Deals.FirstOrDefault(deal => deal.StartDate <= DateTime.Now && deal.EndDate >= DateTime.Now);
                    if (activeDeal != null)
                    {
                        pricePerNight = activeDeal.DealPrice;
                    }
                    else
                    {
                        pricePerNight = room.DailyPrice;
                    }
                    var numberOfNights = (int)(checkOutDate - checkInDate).TotalDays;
                    var totalPrice = numberOfNights * pricePerNight;
                    return totalPrice;
                }
                else
                {
                    _logger.LogError($"Room with ID {roomId} not found.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CalculateTotalPriceAsync: {ex.Message}");
                return 0;
            }
        }
        public async Task<bool> CheckForBookingConflictAsync(BookingDto book)
        {
            try
            {
                var bookingsForRoom = await _bookingRepository.GetBookingsForRoomAsync(book.RoomId);
                foreach (var existingBooking in bookingsForRoom)
                {
                    if (CheckDateRangeOverlap(existingBooking.CheckInDate, existingBooking.CheckOutDate, book.CheckInDate, book.CheckOutDate))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CheckForBookingConflictAsync: {ex.Message}");
                return false;
            }
        }
        public bool CheckDateRangeOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 <= end2 && end1 >= start2;
        }
        public async Task<List<BookingDisplayDto>> GetBookingsByUserAsync(int userId, int page, int pageSize)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId, page, pageSize);
            return _mapper.Map<List<BookingDisplayDto>>(bookings);
        }
        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            return await _bookingRepository.DeleteAsync(bookingId);
        }
        public async Task<BookingDto?> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            return booking != null ? _mapper.Map<BookingDto>(booking) : null;
        }

    }
}
