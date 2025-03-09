using AutoMapper;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class HotelImageProfile : Profile
    {
        public HotelImageProfile()
        {
            CreateMap<HotelImageDisplayDto, HotelImage>().ReverseMap();
        }
    }
}
