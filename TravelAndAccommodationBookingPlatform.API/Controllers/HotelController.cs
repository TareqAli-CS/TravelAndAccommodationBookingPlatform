using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;

namespace TravelAndAccommodationBookingPlatform.API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelsAsync()
        {
            var hotelsDto = await _hotelService.GetAllHotelsAsync();
            return Ok(hotelsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelByIdAsync(int id)
        {
            var hotelDto = await _hotelService.GetHotelByIdAsync(id);

            if (hotelDto == null)
            {
                return NotFound();
            }

            return Ok(hotelDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateHotelAsync([FromBody] HotelDto hotelDto)
        {
            await _hotelService.AddHotelAsync(hotelDto);
            return Ok(new { message = "Hotel Created successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHotelAsync(int id, [FromBody] HotelDto hotelDto)
        {
            var updateResult = await _hotelService.UpdateHotelAsync(id, hotelDto);

            if (updateResult)
            {
                return Ok(new { message = "Hotel updated successfully" });
            }
            else
            {
                return NotFound(new { message = $"Hotel with ID {id} not found" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotelAsync(int id)
        {
            var deletionResult = await _hotelService.DeleteHotelAsync(id);

            if (deletionResult)
            {
                return Ok(new { message = "Hotel deleted successfully" });
            }
            else
            {
                return NotFound(new { message = $"Hotel with ID {id} not found" });
            }
        }

        [HttpGet("filter")]
        [Authorize(Roles = "NormalUser")]
        public async Task<IActionResult> FilterHotelsAsync([FromQuery] HotelFilterDto filterBody)
        {
            var filteredHotels = await _hotelService.FilterHotelsAsync(filterBody);
            return Ok(filteredHotels);
        }

        [HttpGet("deals")]
        [Authorize(Roles = "NormalUser")]
        public async Task<IActionResult> GetHotelsWithAvailableDealsAsync()
        {
            var hotelsWithDealsDto = await _hotelService.GetHotelsWithAvailableDealsAsync();
            return Ok(hotelsWithDealsDto);
        }

        [HttpGet("recently-visited-hotels/{userId}")]
        [Authorize(Roles = "NormalUser")]
        public async Task<IActionResult> GetVisitedHotelsByUserAsync(int userId)
        {
            var visitedHotels = await _hotelService.GetVisitedHotelsByUserAsync(userId);
            return Ok(visitedHotels);
        }
    }
}
