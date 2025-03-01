namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class HotelImage
    {
        public int ImageId { get; set; }
        public int HotelId { get; set; }
        public string ImageUrl { get; set; }
        public Hotel Hotel { get; set; }
    }
}
