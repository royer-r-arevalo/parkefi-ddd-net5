using AutoMapper;
using ParkEFI.Application.Contracts;
using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Mappings
{
    public class ProvinceProfile : Profile
    {
        public ProvinceProfile()
        {
            CreateMap<ProvinceEntity, ProvinceDTO>()
                .ForMember(dest => dest.ProvinceId, opt => opt.MapFrom(src => src.ProvinceId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.CityId))
                ;

            CreateMap<ProvinceCreateDTO, ProvinceEntity>()
                .ConvertUsing<ProvinceCreateConverter>()
                ;

            CreateMap<ProvinceEditDTO, ProvinceEntity>()
                .ConvertUsing<ProvinceEditConverter>()
                ;
        }
    }

    public class ProvinceCreateConverter : ITypeConverter<ProvinceCreateDTO, ProvinceEntity>
    {
        private readonly ICityService _cityService;

        public ProvinceCreateConverter(ICityService cityService)
        {
            _cityService = cityService;
        }

        public ProvinceEntity Convert(ProvinceCreateDTO source, ProvinceEntity destination, ResolutionContext context)
        {
            var city = _cityService.GetCityByIdAsync(source.CityId).Result;
            destination = new ProvinceEntity(source.Name, city);

            return destination;
        }
    }

    public class ProvinceEditConverter : ITypeConverter<ProvinceEditDTO, ProvinceEntity>
    {
        private readonly ICityService _cityService;

        public ProvinceEditConverter(ICityService cityService)
        {
            _cityService = cityService;
        }

        public ProvinceEntity Convert(ProvinceEditDTO source, ProvinceEntity destination, ResolutionContext context)
        {
            var city = _cityService.GetCityByIdAsync(source.CityId).Result;
            destination.ChangeName(source.Name);
            destination.ChangeCity(city);

            return destination;
        }
    }
}
