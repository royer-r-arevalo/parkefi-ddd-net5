//using AutoMapper;
//using ParkEFI.Application.Adapters;
//using ParkEFI.Crosscutting.Utils.Extensions;
//using ParkEFI.Domain.Entities;
//using ParkEFI.Domain.Entities.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ParkEFI.Application.Services.Mappings
//{
//    public class PersonsProfile : Profile
//    {
//        public PersonsProfile()
//        {
//            CreateMap<PersonEntity, PersonBaseDTO>()
//                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Names))
//                .ForMember(dest => dest.FamilyName, opt => opt.MapFrom(src => src.FirstSurname))
//                .ForMember(dest => dest.GivenName, opt => opt.MapFrom(src => src.SecondSurname))
//                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()))
//                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
//                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
//                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
//                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
//                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
//                ;

//            CreateMap<GarageOwnerEntity, GarageOwnerDTO>()
//                .IncludeBase<PersonEntity, PersonBaseDTO>()
//                .ForMember(dest => dest.GarageOwnerId, opt => opt.MapFrom(src => src.Id))
//                ;

//            CreateMap<ParkingOwnerEntity, ParkingOwnerDTO>()
//                .IncludeBase<PersonEntity, PersonBaseDTO>()
//                .ForMember(dest => dest.ParkingOwnerId, opt => opt.MapFrom(src => src.Id))
//                ;

//            CreateMap<GarageOwnerCreateDTO, GarageOwnerEntity>()
//                .ConvertUsing<GarageOwnerCreateConverter>();

//            CreateMap<ParkingOwnerCreateDTO, ParkingOwnerEntity>()
//                .ConvertUsing<ParkingOwnerCreateConverter>();
//        }
//    }

//    public class GarageOwnerCreateConverter : ITypeConverter<GarageOwnerCreateDTO, GarageOwnerEntity>
//    {
//        public GarageOwnerEntity Convert(GarageOwnerCreateDTO source, GarageOwnerEntity destination, ResolutionContext context)
//        {
//            Genders gender;
//            if (source.IsGenderMale)
//                gender = Genders.Male;
//            else if (source.IsGenderFamale)
//                gender = Genders.Female;
//            else if (source.IsGenderOther)
//                gender = Genders.Other;
//            else
//                gender = Genders.Undefined;

//            destination = new GarageOwnerEntity(
//                source.Names,
//                source.FamilyName,
//                source.GivenName,
//                source.BirthDate.ToDate().Value,
//                source.Email,
//                source.PhoneNumber,
//                source.Cedula,
//                gender
//                );

//            return destination;
//        }
//    }

//    public class ParkingOwnerCreateConverter : ITypeConverter<ParkingOwnerCreateDTO, ParkingOwnerEntity>
//    {
//        public ParkingOwnerEntity Convert(ParkingOwnerCreateDTO source, ParkingOwnerEntity destination, ResolutionContext context)
//        {
//            Genders gender;
//            if (source.IsGenderMale)
//                gender = Genders.Male;
//            else if (source.IsGenderFamale)
//                gender = Genders.Female;
//            else if (source.IsGenderOther)
//                gender = Genders.Other;
//            else
//                gender = Genders.Undefined;

//            destination = new ParkingOwnerEntity(
//                source.Names,
//                source.FamilyName,
//                source.GivenName,
//                source.BirthDate.ToDate().Value,
//                source.Email,
//                source.PhoneNumber,
//                source.Cedula,
//                gender
//                );

//            return destination;
//        }
//    }
//}
