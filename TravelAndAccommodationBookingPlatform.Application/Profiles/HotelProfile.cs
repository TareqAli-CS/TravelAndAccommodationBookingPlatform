using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDisplayDto>()
                .ForMember(dest => dest.AveragePricePerNight, opt => opt.MapFrom(src => GetAverageDailyPrice(src)));

            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();
        }

        private decimal GetAverageDailyPrice(Hotel hotel)
        {
            return hotel.Rooms?.Any() == true
                ? hotel.Rooms.Average(room => room.DailyPrice)
                : 0;
        }
    }
}
