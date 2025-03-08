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
        [HttpPost("create")]
        public async Task<IActionResult> CreateDealAsync([FromBody] DealDto dealDto)
        {
            await _dealService.CreateDealAsync(dealDto);
            return Ok("Deal created successfully");
        }
    }
}
