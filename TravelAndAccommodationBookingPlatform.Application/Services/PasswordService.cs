using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class PasswordService : IPasswordService
    {
        public bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPasswordHash);
        }

        public string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }
    }
}
