using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Contracts
{
    public interface IParkingOwnerService
    {
        Task<ParkingOwnerEntity> GetParkingOwnerByIdAsync(int parkingOwnerId);
        Task<ParkingOwnerEntity> CreateParkingOwnerAsync(ParkingOwnerEntity parkingOwner);
        Task CreateParkingOwnerWithUserAsync(ParkingOwnerEntity parkingOwner, UserEntity user);
    }
}
