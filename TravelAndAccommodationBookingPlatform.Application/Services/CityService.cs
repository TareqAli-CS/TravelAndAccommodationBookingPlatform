using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.DtoDisplays;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ICityService> _logger;

        public CityService(ICityRepository cityRepository, IMapper mapper, ILogger<ICityService> logger)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CityDisplayDto>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _cityRepository.GetAllAsync();
                var cityDtos = _mapper.Map<List<CityDisplayDto>>(cities);
                return cityDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllCitiesAsync: {ex.Message}");
                return new List<CityDisplayDto>();
            }
        }

        public async Task<CityDisplayDto> GetCityByIdAsync(int id)
        {
            try
            {
                var city = await _cityRepository.GetByIdAsync(id);
                return _mapper.Map<CityDisplayDto>(city);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetCityByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task AddCityAsync(CityDto cityDto)
        {
            try
            {
                var city = _mapper.Map<City>(cityDto);
                await _cityRepository.AddAsync(city);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddCityAsync: {ex.Message}");
            }
        }

        public async Task<bool> UpdateCityAsync(int id, CityDto cityDto)
        {
            try
            {
                var existingCity = await _cityRepository.GetByIdAsync(id);

                if (existingCity == null)
                {
                    return false;
                }

                _mapper.Map(cityDto, existingCity);
                existingCity.ModifiedAt = DateTime.Now;

                await _cityRepository.UpdateAsync(existingCity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateCityAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            try
            {
                var cityToDelete = await _cityRepository.GetByIdAsync(id);

                if (cityToDelete == null)
                {
                    return false;
                }

                await _cityRepository.DeleteAsync(cityToDelete);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteCityAsync: {ex.Message}");
                return false;
            }
        }
        public async Task<List<CityDisplayDto>> GetTrendingDestinationsAsync()
        {
            try
            {
                var trendingCities = await _cityRepository.GetTrendingDestinationsAsync();
                var trendingCityDtos = _mapper.Map<List<CityDisplayDto>>(trendingCities);

                return trendingCityDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetTrendingDestinationsAsync: {ex.Message}");
                return new List<CityDisplayDto>();
            }
        }
    }
}
