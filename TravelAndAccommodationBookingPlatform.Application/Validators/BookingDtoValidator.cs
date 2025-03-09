using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class BookingDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingDtoValidator()
        {
            RuleFor(dto => dto.RoomId).GreaterThan(0).WithMessage("RoomId must be greater than 0.");
            RuleFor(dto => dto.CheckInDate).NotEmpty().WithMessage("CheckInDate is required.");
            RuleFor(dto => dto.CheckOutDate).NotEmpty().WithMessage("CheckOutDate is required.")
                .Must((dto, checkOutDate) => checkOutDate > dto.CheckInDate)
                .WithMessage("CheckOutDate must be later than CheckInDate.");
        }
    }
}
