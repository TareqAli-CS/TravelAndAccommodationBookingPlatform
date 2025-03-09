using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> ValidateUserCredentialsAsync(string username, string password);
        Task<User> RegisterUserAsync(RegisterUserDto registerUserDto);
    }
}
