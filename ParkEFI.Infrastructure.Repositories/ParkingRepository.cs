using Microsoft.EntityFrameworkCore;
using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Infrastructure.Repositories
{
    public class ParkingRepository : GenericRepository<ParkingEntity>, IParkingRepository
    {
        public ParkingRepository(ParkEFIDbContext db) : base(db)
        {
        }

        public async Task CreateParkingWithPointsAsync(ParkingEntity parking, PointEntity point)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            await CreateAsync(parking);
            await SaveAsync();
            await CreateAsync(parking);
            point.SetForeignKeyOfParkingBase(parking.Id);
            await _db.Points.AddAsync(point);
            await SaveAsync();
            await transaction.CommitAsync();
        }

        public async Task<ParkingEntity> GetParkingByIdAsync(int parkingId)
        {
            var parking = await _db.Parkings
                .Where(p => p.Id == parkingId)
                .Include(p => p.Point)
                .Include(p => p.Country)
                .Include(p => p.City)
                .Include(p => p.Province)
                .Include(p => p.ParkingOwner)
                .Include(p => p.Company)
                .FirstOrDefaultAsync();

            return parking ?? null;
        }
    }
}
