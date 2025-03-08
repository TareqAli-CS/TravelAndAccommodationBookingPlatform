using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TravelAndAccommodationDbContext _context;
        public UserRepository(TravelAndAccommodationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(User user)
        {
            try
            { 
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding the user.", ex);
            }
        }
    }
}
