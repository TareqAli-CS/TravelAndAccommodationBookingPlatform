namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; }
        public List<HotelAmenity> HotelAmenities { get; set; }
    }
}
