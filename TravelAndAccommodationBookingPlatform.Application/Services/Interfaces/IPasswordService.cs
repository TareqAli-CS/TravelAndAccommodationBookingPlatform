namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IPasswordService
    {
        bool VerifyPassword(string enteredPassword, string storedPasswordHash);
        string HashPassword(string plainPassword);
    }
}
