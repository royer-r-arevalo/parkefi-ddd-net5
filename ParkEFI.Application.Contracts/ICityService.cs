using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkEFI.Application.Contracts
{
    public interface ICityService
    {
        Task<IList<CityEntity>> GetCitiesByCountryIdAsync(int countryId);
        Task<CityEntity> GetCityByIdAsync(int cityId);
        Task<CityEntity> CreateCityAsync(CityEntity city);
        Task<CityEntity> EditCityAsync(CityEntity city);
    }
}
