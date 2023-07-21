using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using ParkEFI.Domain.Contracts;

namespace ParkEFI.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<CityEntity>, ICityRepository
    {
        public CityRepository(ParkEFIDbContext db) : base(db)
        {
        }

        public async Task<IList<CityEntity>> GetCitiesAsync()
        {
            var cities = await _db.Cities
                .Where(c => c.Status == EntityStatus.Active)
                .Include(c => c.Country)
                .ToListAsync();

            return cities;
        }

        public async Task<CityEntity> GetCityByIdAsync(int cityId)
        {
            var city = await _db.Cities
                .Where(c => c.CityId == cityId)
                .SingleOrDefaultAsync();

            return city;
        }

        public async Task<IList<CityEntity>> GetCitiesByCountryIdAsync(int countryId)
        {
            var cities = await _db.Cities
                .Where(c => c.Status == EntityStatus.Active)
                .Where(c => c.Country.CountryId == countryId)
                .Include(c => c.Country)
                .ToListAsync();

            return cities;
        }
    }
}
