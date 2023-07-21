//using AutoMapper;
//using ParkEFI.Application.Adapters;
//using ParkEFI.Domain.Contracts;
//using ParkEFI.Domain.Entities;
//using ParkEFI.Domain.Entities.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ParkEFI.Application.Services.Mappings
//{
//    public class CityProfile : Profile
//    {
//        public CityProfile()
//        {
//            CreateMap<CityEntity, CityDTO>()
//                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
//                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
//                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.CountryId))
//                ;

//            CreateMap<CityCreateDTO, CityEntity>()
//                .ConvertUsing<CityCreateConverter>()
//                ;

//            CreateMap<CityEditDTO, CityEntity>()
//                .ConvertUsing<CityEditConverter>()
//                ;
//        }
//    }

//    public class CityCreateConverter : ITypeConverter<CityCreateDTO, CityEntity>
//    {
//        private readonly ICountryRepository _countryRepository;

//        public CityCreateConverter(ICountryRepository countryRepository)
//        {
//            _countryRepository = countryRepository;
//        }

//        public CityEntity Convert(CityCreateDTO source, CityEntity destination, ResolutionContext context)
//        {
//            var country = _countryRepository.GetCountryByIdAsync(source.CountryId).Result;
//            destination = new CityEntity(source.Name, country);

//            return destination;
//        }
//    }

//    public class CityEditConverter : ITypeConverter<CityEditDTO, CityEntity>
//    {
//        private readonly ICountryRepository _countryRepository;

//        public CityEditConverter(ICountryRepository countryRepository)
//        {
//            _countryRepository = countryRepository;
//        }

//        public CityEntity Convert(CityEditDTO source, CityEntity destination, ResolutionContext context)
//        {
//            var country = _countryRepository.GetCountryByIdAsync(source.CountryId).Result;
//            destination.ChangeName(source.Name);
//            destination.ChangeCountry(country);

//            return destination;
//        }
//    }
//}
