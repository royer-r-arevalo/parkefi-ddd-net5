using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface ICityRepository : IGenericRepository<CityEntity>
    {
        Task<IList<CityEntity>> GetCitiesByCountryIdAsync(int countryId);
        Task<CityEntity> GetCityByIdAsync(int cityId);
    }
}
