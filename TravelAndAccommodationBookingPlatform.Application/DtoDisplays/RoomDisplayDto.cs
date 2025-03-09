using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Data.Enums;

namespace TravelAndAccommodationBookingPlatform.Application.DtoDisplays
{
    public class RoomDisplayDto
    {
        public int RoomId { get; set; }
        public int AdultCapacity { get; set; }
        public int ChildCapacity { get; set; }
        public decimal DailyPrice { get; set; }
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int NumberOfRooms { get; set; }
        public List<RoomImageDisplayDto> RoomImages { get; set; } = new List<RoomImageDisplayDto>();
        public List<DealDto> Deals { get; set; } = new List<DealDto>();
        public List<BookingDisplayDto> Bookings { get; set; } = new List<BookingDisplayDto>();

    }
}
