using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ILogger<IUserService> _logger;
        public UserService(IUserRepository userRepository
            , IMapper mapper
            , ILogger<IUserService> logger,
PasswordService passwordService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _passwordService = passwordService;
        }
        public User GetUserByUsername(string username)
        {
            try
            {
                return _userRepository.GetByUsername(username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user by username");
                throw;
            }
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            try
            {
                var user = _userRepository.GetByUsername(username);
                if (user == null)
                {
                    _logger.LogWarning("User not found: {Username}", username);
                    return false;
                }
                return _passwordService.VerifyPassword(password, user.PasswordHash);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating user credentials for username: {Username}", username);
                throw new InvalidOperationException("An error occurred while validating the credentials.", ex);
            }
        }
    }
}
