using AutoMapper;
using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Mappings
{
    public class PersonsProfile : Profile
    {
        public PersonsProfile()
        {
            CreateMap<PersonEntity, PersonDTO>()
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.FamilyName, opt => opt.MapFrom(src => src.FirstSurname))
                .ForMember(dest => dest.GivenName, opt => opt.MapFrom(src => src.SecondSurname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != EntityStatus.Active))
                ;

            CreateMap<GarageOwnerEntity, GarageOwnerDTO>()
                .IncludeBase<PersonEntity, PersonDTO>()
                .ForMember(dest => dest.GarageOwnerId, opt => opt.MapFrom(src => src.Id))
                ;

            CreateMap<ParkingOwnerEntity, ParkingOwnerDTO>()
                .IncludeBase<PersonEntity, PersonDTO>()
                .ForMember(dest => dest.ParkingOwnerId, opt => opt.MapFrom(src => src.Id))
                ;
        }
    }
}
