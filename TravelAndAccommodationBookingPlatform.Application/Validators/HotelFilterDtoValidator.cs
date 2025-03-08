using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class HotelFilterDtoValidator : AbstractValidator<HotelFilterDto>
    {
        public HotelFilterDtoValidator()
        {
            RuleFor(dto => dto.MinPrice).GreaterThanOrEqualTo(0).When(dto => dto.MinPrice.HasValue)
            .WithMessage("MinPrice must be greater than or equal to 0 when provided.");

            RuleFor(dto => dto.MaxPrice).GreaterThanOrEqualTo(0).When(dto => dto.MaxPrice.HasValue)
                .WithMessage("MaxPrice must be greater than or equal to 0 when provided.");

            RuleFor(dto => dto.MaxPrice).GreaterThanOrEqualTo(dto => dto.MinPrice).When(dto => dto.MinPrice.HasValue && dto.MaxPrice.HasValue)
                .WithMessage("MaxPrice must be greater than or equal to MinPrice.");

            RuleFor(dto => dto.StarRating).InclusiveBetween(1, 5).When(dto => dto.StarRating.HasValue)
                .WithMessage("StarRating must be between 1 and 5 when provided.");

            RuleFor(dto => dto.AmenitiesIds).Must(ids => ids != null && ids.Any()).When(dto => dto.AmenitiesIds != null)
                .WithMessage("AmenitiesIds must not be null or empty when provided.");

            RuleFor(dto => dto.RoomType).IsInEnum().When(dto => dto.RoomType.HasValue)
                .WithMessage("Invalid RoomType value.");

        }
    }
}
