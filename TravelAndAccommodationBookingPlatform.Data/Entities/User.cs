﻿using TravelAndAccommodationBookingPlatform.Data.Enums;

namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
