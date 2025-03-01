using TravelAndAccommodationBookingPlatform.Data.Enums;

namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int AdultCapacity { get; set; }
        public int ChildCapacity { get; set; }
        public decimal DailyPrice { get; set; }
        public RoomType RoomType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int NumberOfRooms { get; set; }
        public Hotel Hotel { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<Deal> Deals { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
