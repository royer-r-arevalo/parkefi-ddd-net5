//using AutoMapper;
//using ParkEFI.Application.Adapters;
//using ParkEFI.Domain.Entities;
//using ParkEFI.Domain.Entities.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ParkEFI.Application.Services.Mappings
//{
//    public class CountryProfile : Profile
//    {
//        public CountryProfile()
//        {
//            CreateMap<CountryEntity, CountryDTO>()
//                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
//                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
//                ;

//            CreateMap<CountryCreateDTO, CountryEntity>()
//                .ConvertUsing<CountryCreateConverter>()
//                ;

//            CreateMap<CountryEditDTO, CountryEntity>()
//                .ConvertUsing<CountryEditConverter>()
//                ;
//        }
//    }

//    public class CountryCreateConverter : ITypeConverter<CountryCreateDTO, CountryEntity>
//    {
//        public CountryEntity Convert(CountryCreateDTO source, CountryEntity destination, ResolutionContext context)
//        {
//            destination = new CountryEntity(source.Name);
//            return destination;
//        }
//    }

//    public class CountryEditConverter : ITypeConverter<CountryEditDTO, CountryEntity>
//    {
//        public CountryEntity Convert(CountryEditDTO source, CountryEntity destination, ResolutionContext context)
//        {
//            destination.ChangeName(source.Name);
//            return destination;
//        }
//    }
//}
