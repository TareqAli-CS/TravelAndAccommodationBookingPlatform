using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }
            int userId = int.Parse(userIdClaim);
            bookingDto.UserId = userId;
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
        [HttpGet]
        public async Task<IActionResult> GetBookingsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            int userId = int.Parse(userIdClaim);

            var bookings = await _bookingService.GetBookingsByUserAsync(userId, page, pageSize);

            return Ok(bookings);
        }
        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBookingAsync(int bookingId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity?.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }
            int userId = int.Parse(userIdClaim);
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            if (booking == null)
            {
                return NotFound(new { message = "Booking not found" });
            }
            if (booking.UserId != userId)
            {
                return Forbid();
            }
            bool result = await _bookingService.DeleteBookingAsync(bookingId);
            if (result)
            {
                return Ok(new { message = "Booking deleted successfully" });
            }
            else
            {
                return StatusCode(500, new { message = "Error deleting booking" });
            }
        }

    }
}
