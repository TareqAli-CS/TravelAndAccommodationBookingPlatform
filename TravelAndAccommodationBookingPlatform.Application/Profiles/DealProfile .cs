using AutoMapper;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class DealProfile : Profile
    {
        public DealProfile()
        {
            CreateMap<Deal, DealDto>().ReverseMap();
        }

    }
}
