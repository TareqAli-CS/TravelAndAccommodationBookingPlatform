using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;
using TravelAndAccommodationBookingPlatform.Data.Entities;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class DealService : IDealService
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IDealService> _logger;
        public DealService(IDealRepository dealRepository, IMapper mapper, ILogger<IDealService> logger)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateDealAsync(DealDto dealDto)
        {
            try
            {
                var newDeal = _mapper.Map<Deal>(dealDto);

                if (await DealExistsForRoomAsync(newDeal.RoomId, newDeal.StartDate, newDeal.EndDate))
                {
                    throw new ArgumentException("A deal already exists for the same room during the specified time period.");
                }
                await _dealRepository.AddAsync(newDeal);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DealService.CreateDealAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DealExistsForRoomAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            var existingDeal = await _dealRepository.GetDealByRoomAndDateAsync(roomId, startDate, endDate);
            return existingDeal != null;
        }
    }
}
