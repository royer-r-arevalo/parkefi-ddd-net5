using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Contracts
{
    public interface ICountryService
    {
        Task<IList<CountryEntity>> GetAllCountriesAsync();
        Task<CountryEntity> GetCountryByIdAsync(int countryId);
        Task<CountryEntity> CreateCountryAsync(CountryEntity country);
        Task<CountryEntity> EditCountryAsync(CountryEntity country);
    }
}
