using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
