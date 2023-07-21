using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Contracts
{
    public interface IProvinceService 
    {
        Task<IList<ProvinceEntity>> GetProvincesByCityIdAsync(int cityId);
        Task<ProvinceEntity> GetProvinceByIdAsync(int provinceId);
        Task<ProvinceEntity> CreateProvinceAsync(ProvinceEntity province);
        Task<ProvinceEntity> EditProvinceAsync(ProvinceEntity province);
    }
}
