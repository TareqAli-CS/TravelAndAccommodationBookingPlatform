namespace TravelAndAccommodationBookingPlatform.Application.DtoDisplays
{
    public class HotelDisplayDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public decimal AveragePricePerNight { get; set; }
        public List<ReviewDisplayDto> Reviews { get; set; } = new List<ReviewDisplayDto>();
        public List<HotelImageDisplayDto> HotelImages { get; set; } = new List<HotelImageDisplayDto>();
        public List<RoomDisplayDto> Rooms { get; set; } = new List<RoomDisplayDto>();
    }
}
