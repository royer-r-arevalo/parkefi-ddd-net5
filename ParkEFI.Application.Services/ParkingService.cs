using Microsoft.Extensions.Logging;
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
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingService(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        public async Task CreateParkingAsync(ParkingEntity parking)
        {
            await _parkingRepository.CreateAsync(parking);
        }

        public async Task CreateParkingWithPointsAsync(ParkingEntity parking, PointEntity point)
        {
            await _parkingRepository.CreateParkingWithPointsAsync(parking, point);
        }

        public async Task<ParkingEntity> GetParkingByIdAsync(int parkingId)
        {
            var parking = await _parkingRepository.GetParkingByIdAsync(parkingId);
            return parking;
        }
    }
}
