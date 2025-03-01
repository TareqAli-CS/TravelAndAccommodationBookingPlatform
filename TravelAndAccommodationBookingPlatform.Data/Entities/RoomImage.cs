namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class RoomImage
    {
        public int ImageId { get; set; }
        public int RoomId { get; set; }
        public string ImageUrl { get; set; }
        public Room Room { get; set; }
    }
}
