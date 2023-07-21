using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface IProvinceRepository : IGenericRepository<ProvinceEntity>
    {
        Task<IList<ProvinceEntity>> GetProvincesAsync();
        Task<IList<ProvinceEntity>> GetProvincesByCityIdAsync(int cityId);
        Task<ProvinceEntity> GetProvinceByIdAsync(int provinceId);
    }
}
