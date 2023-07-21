using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Contracts
{
    public interface IParkingService
    {
        Task<ParkingEntity> GetParkingByIdAsync(int parkingId);
        Task CreateParkingAsync(ParkingEntity parking);
        Task CreateParkingWithPointsAsync(ParkingEntity parking, PointEntity entity);
    }
}
