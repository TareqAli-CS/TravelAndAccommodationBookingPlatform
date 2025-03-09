using FluentValidation;
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
