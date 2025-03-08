using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Enums;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ILogger<IUserService> _logger;
        public UserService(IUserRepository userRepository
            , IMapper mapper
            , ILogger<IUserService> logger,
            IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _passwordService = passwordService;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _userRepository.GetByUsernameAsync(username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user by username");
                throw;
            }
        }


        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(username);
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
        public async Task<User> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            try
            {
                if (await _userRepository.GetByUsernameAsync(registerUserDto.Username) != null)
                {
                    throw new ArgumentException("Username is already taken.");
                }

                if (await _userRepository.GetByEmailAsync(registerUserDto.Email) != null)
                {
                    throw new ArgumentException("Email is already taken.");
                }

                if (registerUserDto.Password != registerUserDto.ConfirmPassword)
                {
                    throw new ArgumentException("Passwords do not match.");
                }

                var hashedPassword = _passwordService.HashPassword(registerUserDto.Password);

                var newUser = new User
                {
                    Username = registerUserDto.Username,
                    Email = registerUserDto.Email,
                    PasswordHash = hashedPassword,
                    Role = UserRole.NormalUser // NormalUser is the default role for new users
                };

                await _userRepository.AddAsync(newUser);
                return newUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration.");
                throw;
            }
        }
    }
}
