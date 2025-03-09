using FluentValidation;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class RoomDtoValidator : AbstractValidator<RoomDto>
    {
        public RoomDtoValidator()
        {
            RuleFor(dto => dto.AdultCapacity).GreaterThanOrEqualTo(0).WithMessage("Adult capacity should be a non-negative number.");
            RuleFor(dto => dto.ChildCapacity).GreaterThanOrEqualTo(0).WithMessage("Child capacity should be a non-negative number.");
            RuleFor(dto => dto.DailyPrice).GreaterThan(0).WithMessage("Daily Price should be greater than 0.");
            RuleFor(dto => dto.HotelId).GreaterThan(0).WithMessage("Hotel ID should be greater than 0.");
            RuleFor(dto => dto.RoomType).IsInEnum().WithMessage("Invalid room type.");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(dto => dto.NumberOfRooms).GreaterThan(0).WithMessage("Number of rooms should be greater than 0.");
        }
    }
}
