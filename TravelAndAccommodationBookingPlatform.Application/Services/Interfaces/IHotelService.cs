using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<HotelDisplayDto>> GetAllHotelsAsync(int page, int pageSize);
        Task<HotelDisplayDto> GetHotelByIdAsync(int id);
        Task AddHotelAsync(HotelDto hotelDto);
        Task<bool> UpdateHotelAsync(int id, HotelDto hotelDto);
        Task<bool> DeleteHotelAsync(int id);
        Task<List<HotelDisplayDto>> FilterHotelsAsync(HotelFilterDto filterBody);
        Task<List<HotelDisplayDto>> GetVisitedHotelsByUserAsync(int userId);
        Task<List<HotelDisplayDto>> GetHotelsWithAvailableDealsAsync();
    }
}
