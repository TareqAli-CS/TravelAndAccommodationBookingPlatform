﻿using AutoMapper;
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
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDisplayDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
