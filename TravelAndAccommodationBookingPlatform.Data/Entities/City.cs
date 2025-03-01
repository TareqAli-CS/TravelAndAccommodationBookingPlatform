namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PostOffice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ImageUrl { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
