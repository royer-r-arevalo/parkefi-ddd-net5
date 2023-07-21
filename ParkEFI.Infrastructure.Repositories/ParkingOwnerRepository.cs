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
    public class ParkingOwnerRepository : GenericRepository<ParkingOwnerEntity>, IParkingOwnerRepository
    {
        public ParkingOwnerRepository(ParkEFIDbContext db) : base(db)
        {

        }

        public async Task CreateParkingOwnerWithUserAsync(ParkingOwnerEntity parkingOwner, UserEntity user)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            await CreateAsync(parkingOwner);
            user.SetForeignKeyOfPerson(parkingOwner.Id);
            await _db.Users.AddAsync(user);
            await SaveAsync();
            await transaction.CommitAsync();
        }

        public async Task<ParkingOwnerEntity> GetParkingOwnerByIdAsync(int parkingOwnerId)
        {
            var parkingOwner = await _db.ParkingOwners
                .Where(p => p.Id == parkingOwnerId)
                .FirstOrDefaultAsync();

            return parkingOwner;
        }
    }
}
