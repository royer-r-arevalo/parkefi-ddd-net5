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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<IList<ProvinceEntity>> GetProvincesByCityIdAsync(int cityId)
        {
            var provinces = await _provinceRepository.GetProvincesByCityIdAsync(cityId);
            return provinces;
        }

        public async Task<ProvinceEntity> CreateProvinceAsync(ProvinceEntity province)
        {
            await _provinceRepository.CreateAsync(province);
            return province;
        }

        public async Task<ProvinceEntity> EditProvinceAsync(ProvinceEntity province)
        {
            await _provinceRepository.EditAsync(province);
            return province;
        }

        public async Task<ProvinceEntity> GetProvinceByIdAsync(int provinceId)
        {
            var province = await _provinceRepository.GetProvinceByIdAsync(provinceId);
            return province;
        }
    }
}
