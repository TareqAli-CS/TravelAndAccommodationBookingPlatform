using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IPasswordService
    {
        bool VerifyPassword(string enteredPassword, string storedPasswordHash);
        string HashPassword(string plainPassword);
    }
}
