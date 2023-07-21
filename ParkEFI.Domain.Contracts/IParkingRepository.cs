using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface IParkingRepository : IGenericRepository<ParkingEntity>
    {
        Task CreateParkingWithPointsAsync(ParkingEntity parking, PointEntity point);
        Task<ParkingEntity> GetParkingByIdAsync(int parkingId);
    }
}
