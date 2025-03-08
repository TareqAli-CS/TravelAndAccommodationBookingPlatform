using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;

namespace TravelAndAccommodationBookingPlatform.API.Controllers
{
    [Route("api/booking")]
    [ApiController]
    [Authorize(Roles = "NormalUser")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookingAsync([FromBody] BookingDto bookingDto)
        {
            bool result = await _bookingService.CreateBookingAsync(bookingDto);

            if (result)
            {
                return Ok(new { message = "Booking Created successfully" });
            }
            else
            {
                return Conflict("Booking conflict detected. Cannot create the booking.");
            }
        }
    }
}
