using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ParkEFI.Application.Contracts;
using ParkEFI.Crosscutting.Identity.Models;
using ParkEFI.Crosscutting.Utils.Extensions;
using ParkEFI.Domain.Entities;
using ParkEFI.UI.RESTful.Models;

namespace ParkEFI.UI.RESTful.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDTO, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => GetUserName(src)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                ;

            CreateMap<UserCreateDTO, ApplicationRole>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleType.ToEnum<RoleTypes>().ToString()))
                 ;

            CreateMap<ApplicationUser, UserDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.UserNameConfirmed, opt => opt.MapFrom(src => UserNameConfirmed(src)))
               ;

            CreateMap<UserCreateDTO, GarageOwnerEntity>()
                .ConvertUsing<GarageOwnerCreateConverter>();

            CreateMap<UserCreateDTO, ParkingOwnerEntity>()
                .ConvertUsing<ParkingOwnerCreateConverter>();
        }

        private static bool UserNameConfirmed(ApplicationUser appUser)
        {
            return appUser.EmailConfirmed;
        }

        private static string GetUserName(UserCreateDTO user)
        {
            return user.UserNameType.ToEnum<UserNameTypes>() switch
            {
                UserNameTypes.Email => user.Email,
                UserNameTypes.PhoneNumber => user.PhoneNumber,
                _ => user.UserName,
            };
        }
    }

    public class GarageOwnerCreateConverter : ITypeConverter<UserCreateDTO, GarageOwnerEntity>
    {
        public GarageOwnerEntity Convert(UserCreateDTO source, GarageOwnerEntity destination, ResolutionContext context)
        {
            destination = new GarageOwnerEntity(
                source.Names,
                source.FamilyName,
                source.GivenName,
                source.BirthDate.ToDate().Value,
                source.Email,
                source.PhoneNumber,
                source.Cedula,
                source.Gender.ToEnum<Domain.Entities.Enums.Genders>(),
                new UserEntity(source.UserName)
                );

            return destination;
        }
    }

    public class ParkingOwnerCreateConverter : ITypeConverter<UserCreateDTO, ParkingOwnerEntity>
    {
        public ParkingOwnerEntity Convert(UserCreateDTO source, ParkingOwnerEntity destination, ResolutionContext context)
        {
            destination = new ParkingOwnerEntity(
                source.Names,
                source.FamilyName,
                source.GivenName,
                source.BirthDate.ToDate().Value,
                source.Email,
                source.PhoneNumber,
                source.Cedula,
                source.Gender.ToEnum<Domain.Entities.Enums.Genders>(),
                new UserEntity(source.UserName)
                );

            return destination;
        }
    }
}
