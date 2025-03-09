namespace TravelAndAccommodationBookingPlatform.Application.Dtos
{
    public class DealDto
    {
        public int RoomId { get; set; }
        public decimal DealPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StarRating { get; set; }
    }
}
