using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Data.Enums;

namespace TravelAndAccommodationBookingPlatform.Application.Dtos
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public int AdultCapacity { get; set; }
        public int ChildCapacity { get; set; }
        public decimal DailyPrice { get; set; }
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
