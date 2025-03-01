﻿namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public Hotel Hotel { get; set; }
        public User User { get; set; }
    }
}
