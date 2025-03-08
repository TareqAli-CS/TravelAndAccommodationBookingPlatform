using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;

namespace TravelAndAccommodationBookingPlatform.API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityByIdAsync(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCityAsync([FromBody] CityDto cityDto)
        {
            await _cityService.AddCityAsync(cityDto);
            return Ok(new { message = "City Created successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCityAsync(int id, [FromBody] CityDto cityDto)
        {
            var updateResult = await _cityService.UpdateCityAsync(id, cityDto);

            if (updateResult)
            {
                return Ok(new { message = "City updated successfully" });
            }
            else
            {
                return NotFound(new { message = $"City with ID {id} not found" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            var deletionResult = await _cityService.DeleteCityAsync(id);

            if (deletionResult)
            {
                return Ok(new { message = "City deleted successfully" });
            }
            else
            {
                return NotFound(new { message = $"City with ID {id} not found" });
            }
        }

        [HttpGet("trending")]
        [Authorize(Roles = "NormalUser")]
        public async Task<IActionResult> GetTrendingDestinationsAsync()
        {
            var trendingCities = await _cityService.GetTrendingDestinationsAsync();

            if (trendingCities.Any())
            {
                return Ok(trendingCities);
            }

            return NoContent();
        }
    }
}
