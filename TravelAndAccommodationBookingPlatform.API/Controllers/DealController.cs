using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;

namespace TravelAndAccommodationBookingPlatform.API.Controllers
{
    [Route("api/deals")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDealAsync([FromBody] DealDto dealDto)
        {
            try
            {
                await _dealService.CreateDealAsync(dealDto);
                return Ok("Deal created successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the deal." });
            }
        }

    }
}
