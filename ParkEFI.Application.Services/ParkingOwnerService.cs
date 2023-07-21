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
    public class ParkingOwnerService : IParkingOwnerService
    {
        private readonly IParkingOwnerRepository _parkingOwnerRepository;
        private readonly IUserRepository _userRepository;

        public ParkingOwnerService(IParkingOwnerRepository parkingOwnerRepository, IUserRepository userRepository)
        {
            _parkingOwnerRepository = parkingOwnerRepository;
            _userRepository = userRepository;
        }

        public async Task<ParkingOwnerEntity> CreateParkingOwnerAsync(ParkingOwnerEntity parkingOwner)
        {
            await _parkingOwnerRepository.CreateAsync(parkingOwner);
            return parkingOwner;
        }

        public async Task CreateParkingOwnerWithUserAsync(ParkingOwnerEntity parkingOwner, UserEntity user)
        {
            await _parkingOwnerRepository.CreateParkingOwnerWithUserAsync(parkingOwner, user);
        }

        public async Task<ParkingOwnerEntity> GetParkingOwnerByIdAsync(int parkingOwnerId)
        {
            var parkingOwner = await _parkingOwnerRepository.GetParkingOwnerByIdAsync(parkingOwnerId);
            return parkingOwner;
        }
    }
}
