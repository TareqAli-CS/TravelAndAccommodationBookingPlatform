using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDisplayDto>> GetAllRoomsAsync();
        Task<RoomDisplayDto> GetRoomByIdAsync(int id);
        Task AddRoomAsync(RoomDto roomDto);
        Task<bool> UpdateRoomAsync(int id, RoomDto roomDto);
        Task<bool> DeleteRoomAsync(int id);
    }
}
