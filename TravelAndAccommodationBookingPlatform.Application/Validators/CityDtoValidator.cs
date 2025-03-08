using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class CityDtoValidator : AbstractValidator<CityDto>
    {
        public CityDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(dto => dto.Country).NotEmpty().WithMessage("Country is required.");
            RuleFor(dto => dto.PostOffice).NotEmpty().WithMessage("PostOffice is required.");
        }
    }
}
