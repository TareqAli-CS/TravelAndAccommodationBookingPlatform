using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IDealService
    {
        Task CreateDealAsync(DealDto dealDto);
        Task<bool> DealExistsForRoomAsync(int roomId, DateTime startDate, DateTime endDate);
    }
}
