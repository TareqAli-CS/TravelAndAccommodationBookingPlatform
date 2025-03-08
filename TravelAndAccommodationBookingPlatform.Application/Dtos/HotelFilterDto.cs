using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Data.Enums;

namespace TravelAndAccommodationBookingPlatform.Application.Dtos
{
    public class HotelFilterDto
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? StarRating { get; set; }
        public List<int>? AmenitiesIds { get; set; }
        public RoomType? RoomType { get; set; }
    }
}
