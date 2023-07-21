using AutoMapper;
using ParkEFI.Application.Contracts;
using ParkEFI.Crosscutting.Utils.Extensions;
using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Mappings
{
    public class ParkingProfile : Profile
    {
        public ParkingProfile()
        {
            CreateMap<ParkingEntity, ParkingDTO>()
                .ForMember(dest => dest.ParkingId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.InfraestructureType, opt => opt.MapFrom(src => src.InfraestructureType))
                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
                .AfterMap((src, dest, context) => {
                    dest.Point = context.Mapper.Map<PointDTO>(src.Point);
                    dest.Country = context.Mapper.Map<CountryDTO>(src.Country);
                    dest.City = context.Mapper.Map<CityDTO>(src.City);
                    dest.Province = context.Mapper.Map<ProvinceDTO>(src.Province);
                })
                ;

            CreateMap<ParkingCreateDTO, ParkingEntity>()
                .ConvertUsing<ParkingCreateConverter>()
                ;
        }
    }

    public class ParkingCreateConverter : ITypeConverter<ParkingCreateDTO, ParkingEntity>
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;
        private readonly IParkingOwnerService _parkingOwnerService;

        public ParkingCreateConverter(ICountryService countryService, ICityService cityService, IProvinceService provinceService, IParkingOwnerService parkingOwnerService)
        {
            _countryService = countryService;
            _cityService = cityService;
            _provinceService = provinceService;
            _parkingOwnerService = parkingOwnerService;
        }

        public ParkingEntity Convert(ParkingCreateDTO source, ParkingEntity destination, ResolutionContext context)
        {
            var point = context.Mapper.Map<PointEntity>(source.Point);
            var country = _countryService.GetCountryByIdAsync(source.CountryId).Result;

            CompanyEntity company = null;
            ParkingOwnerEntity parkingOwner = null;
            if (source.CompanyId.HasValue)
            {
                company = null;
            }
            else if (source.ParkingOwnerId.HasValue)
            {
                parkingOwner = _parkingOwnerService.GetParkingOwnerByIdAsync(source.ParkingOwnerId.Value).Result;
            }
            
            CityEntity city = null;
            if (source.CityId.HasValue)
            {
                city = _cityService.GetCityByIdAsync(source.CityId.Value).Result;
            }

            ProvinceEntity province = null;
            if (source.ProvinceId.HasValue)
            {
                province = _provinceService.GetProvinceByIdAsync(source.ProvinceId.Value).Result;
            }

            destination = new ParkingEntity(
                source.Name,
                source.InfrastructureType.ToEnum<InfraestructureTypes>(),
                source.Description,
                source.PostalCode,
                point,
                parkingOwner,
                company,
                country,
                city,
                province
                );
            return destination;
        }
    }
}
