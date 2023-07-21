using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ParkEFI.Application.Contracts;
using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using ParkEFI.UI.RESTful.Models;


namespace ParkEFI.UI.RESTful.Mappings
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntity, CityDTO>()
              .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
              .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.CountryId))
              ;

            CreateMap<CityCreateDTO, CityEntity>()
                .ConvertUsing<CityCreateConverter>()
                ;

            CreateMap<CityEditDTO, CityEntity>()
                .ConvertUsing<CityEditConverter>()
                ;
        }
        public class CityCreateConverter : ITypeConverter<CityCreateDTO, CityEntity>
        {
            private readonly ICountryService _countryService;

            public CityCreateConverter(ICountryService countryService)
            {
                _countryService = countryService;
            }

            public CityEntity Convert(CityCreateDTO source, CityEntity destination, ResolutionContext context)
            {
                var country = _countryService.GetCountryByIdAsync(source.CountryId).Result;
                destination = new CityEntity(source.Name, country);

                return destination;
            }
        }

        public class CityEditConverter : ITypeConverter<CityEditDTO, CityEntity>
        {
            private readonly ICountryService _countryService;

            public CityEditConverter(ICountryService countryService)
            {
                _countryService = countryService;
            }

            public CityEntity Convert(CityEditDTO source, CityEntity destination, ResolutionContext context)
            {
                var country = _countryService.GetCountryByIdAsync(source.CountryId).Result;
                destination.ChangeName(source.Name);
                destination.ChangeCountry(country);

                return destination;
            }
        }

    }
}
