using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class HotelDtoValidator : AbstractValidator<HotelDto>
    {
        public HotelDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(dto => dto.StarRating).InclusiveBetween(1, 5).WithMessage("StarRating must be between 1 and 5.");
            RuleFor(dto => dto.Owner).NotEmpty().WithMessage("Owner is required.");
            RuleFor(dto => dto.Location).NotEmpty().WithMessage("Location is required.");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(dto => dto.CityId).GreaterThan(0).WithMessage("CityId must be greater than 0.");
        }
    }
}
