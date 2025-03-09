using AutoMapper;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class RoomImageProfile : Profile
    {
        public RoomImageProfile()
        {
            CreateMap<RoomImageDisplayDto, RoomImage>().ReverseMap();
        }
    }
}
