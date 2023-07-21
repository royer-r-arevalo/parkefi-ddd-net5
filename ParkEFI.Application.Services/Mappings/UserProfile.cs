//using AutoMapper;
//using ParkEFI.Application.Adapters;
//using ParkEFI.Domain.Contracts;
//using ParkEFI.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ParkEFI.Application.Services.Mappings
//{
//    public class UserProfile : Profile
//    {
//        public UserProfile()
//        {
//            CreateMap<UserEntity, UserDTO>()
//                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
//                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
//                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => src.Status != Domain.Entities.Enums.EntityStatus.Active))
//                ;

//            CreateMap<UserCreateDTO, UserEntity>()
//                .ConvertUsing<UserCreateConverter>()
//                ;
//        }
//    }

//    public class UserCreateConverter : ITypeConverter<UserCreateDTO, UserEntity>
//    {
//        private readonly IGarageOwnerRepository _garageOwnerRepository;
//        private readonly IParkingOwnerRepository _parkingOwnerRepository;

//        public UserCreateConverter(IGarageOwnerRepository garageOwnerRepository, IParkingOwnerRepository parkingOwnerRepository)
//        {
//            _garageOwnerRepository = garageOwnerRepository;
//            _parkingOwnerRepository = parkingOwnerRepository;
//        }

//        public UserEntity Convert(UserCreateDTO source, UserEntity destination, ResolutionContext context)
//        {
//            PersonEntity person = null;
//            if (source.GarageOwnerId.HasValue)
//                person = _garageOwnerRepository.GetGarageOwnerByIdAsync(source.GarageOwnerId.Value).Result;
//            else if (source.ParkingOwnerId.HasValue)
//                person = _parkingOwnerRepository.GetParkingOwnerByIdAsync(source.ParkingOwnerId.Value).Result;

//            return new UserEntity(source.UserName, person);
//        }
//    }
//}
