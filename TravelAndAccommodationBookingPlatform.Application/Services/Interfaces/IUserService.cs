using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        bool ValidateUserCredentials(string username, string password);
    }
}
