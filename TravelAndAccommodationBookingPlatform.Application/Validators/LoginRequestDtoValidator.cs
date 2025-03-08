using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator() 
        {
            RuleFor(request => request.Username)
                .NotEmpty().WithMessage("Username cannot be empty")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(5).WithMessage("Password must be at least 5 characters");
        }
    }
}
