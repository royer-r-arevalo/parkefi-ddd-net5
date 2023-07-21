using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface ICountryRepository : IGenericRepository<CountryEntity>
    {
        Task<IList<CountryEntity>> GetCountriesAsync();
        Task<CountryEntity> GetCountryByIdAsync(int countryId);
    }
}
