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
    public class ProvinceRepository : GenericRepository<ProvinceEntity>, IProvinceRepository
    {
        public ProvinceRepository(ParkEFIDbContext db) : base(db)
        {
        }

        public async Task<IList<ProvinceEntity>> GetProvincesAsync()
        {
            var provinces = await _db.Provinces
                .Where(p => p.Status == EntityStatus.Active)
                .ToListAsync();

            return provinces;
        }

        public async Task<IList<ProvinceEntity>> GetProvincesByCityIdAsync(int cityId)
        {
            var provinces = await _db.Provinces
                .Where(p => p.Status == EntityStatus.Active)
                .Where(p => p.City.CityId == cityId)
                .ToListAsync();

            return provinces;
        }

        public async Task<ProvinceEntity> GetProvinceByIdAsync(int provinceId)
        {
            var province = await _db.Provinces
                .Where(p => p.ProvinceId == provinceId)
                .FirstOrDefaultAsync();

            return province;
        }
    }
}
