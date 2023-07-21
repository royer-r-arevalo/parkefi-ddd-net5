using Microsoft.Extensions.Logging;
using ParkEFI.Application.Contracts;
using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger _logger;

        public CountryService(ICountryRepository countryRepository, ILogger<CountryService> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<IList<CountryEntity>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetCountriesAsync();
            return countries;
        }

        public async Task<CountryEntity> CreateCountryAsync(CountryEntity country)
        {
            await _countryRepository.CreateAsync(country);
            return country;
        }

        public async Task<CountryEntity> EditCountryAsync(CountryEntity country)
        {
            await _countryRepository.EditAsync(country);
            return country;
        }

        public async Task<CountryEntity> GetCountryByIdAsync(int countryId)
        {
            var country = await _countryRepository.GetCountryByIdAsync(countryId);
            return country;
        }
    }
}
