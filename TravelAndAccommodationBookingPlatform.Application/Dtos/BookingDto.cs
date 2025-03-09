using System.Text.Json.Serialization;

namespace TravelAndAccommodationBookingPlatform.Application.Dtos
{
    public class BookingDto
    {
        [JsonIgnore] // hide the field in swagger 
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
