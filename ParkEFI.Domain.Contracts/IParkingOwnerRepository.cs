using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface IParkingOwnerRepository : IGenericRepository<ParkingOwnerEntity>
    {
        Task<ParkingOwnerEntity> GetParkingOwnerByIdAsync(int parkingOwnerId);
        Task CreateParkingOwnerWithUserAsync(ParkingOwnerEntity parkingOwner, UserEntity entity);
    }
}
