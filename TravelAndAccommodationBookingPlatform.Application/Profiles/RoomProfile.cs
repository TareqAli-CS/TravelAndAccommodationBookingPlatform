﻿using AutoMapper;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Data.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDisplayDto>()
               .ForMember(dest => dest.Deals, opt => opt.MapFrom(src => src.Deals))
               .ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
