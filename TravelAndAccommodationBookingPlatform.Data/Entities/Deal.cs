namespace TravelAndAccommodationBookingPlatform.Data.Entities
{
    public class Deal
    {
        public int DealId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public decimal DealPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
