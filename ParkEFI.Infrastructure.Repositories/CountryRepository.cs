using Microsoft.EntityFrameworkCore;
using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Infrastructure.Repositories
{
    public class CountryRepository: GenericRepository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(ParkEFIDbContext db): base(db)
        {
        }

        public async Task<IList<CountryEntity>> GetCountriesAsync()
        {
            var countries = await _db.Countries
                .Where(c => c.Status == EntityStatus.Active)
                .ToListAsync();

            return countries;
        }

        public async Task<CountryEntity> GetCountryByIdAsync(int countryId)
        {
            var country = await _db.Countries
                .Where(c => c.CountryId == countryId)
                .FirstOrDefaultAsync();

            return country;
        }
    }
}
