using Microsoft.Extensions.Logging;
using ParkEFI.Application.Contracts;
using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkEFI.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger _logger;


        public CityService(ICityRepository cityRepository, ILogger<CityService> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public async Task<IList<CityEntity>> GetCitiesByCountryIdAsync(int countryId)
        {
            var cities = await _cityRepository.GetCitiesByCountryIdAsync(countryId);
            return cities;
        }

        public async Task<CityEntity> CreateCityAsync(CityEntity city)
        {
            await _cityRepository.CreateAsync(city);          
            return city;
        }

        public async Task<CityEntity> EditCityAsync(CityEntity city)
        {
            await _cityRepository.EditAsync(city);
            return city;
        }

        public Task<CityEntity> GetCityByIdAsync(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
