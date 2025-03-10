﻿namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public City City { get; set; }
        public List<HotelImage> HotelImages { get; set; }
        public List<HotelAmenity> HotelAmenities { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
