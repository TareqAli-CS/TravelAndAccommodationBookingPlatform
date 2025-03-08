using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class DealDtoValidator : AbstractValidator<DealDto>
    {
        public DealDtoValidator()
        {
            RuleFor(dto => dto.RoomId).GreaterThan(0).WithMessage("RoomId must be greater than 0.");
            RuleFor(dto => dto.DealPrice).GreaterThan(0).WithMessage("DealPrice must be greater than 0.");

            RuleFor(dto => dto.StartDate)
                .NotEmpty().WithMessage("StartDate is required.")
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("StartDate must be greater than or equal to the current date.");

            RuleFor(dto => dto.EndDate)
                .NotEmpty().WithMessage("EndDate is required.")
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("EndDate must be greater than or equal to the current date.")
                .GreaterThan(dto => dto.StartDate).WithMessage("EndDate must be greater than StartDate.");
        }
    }
}
