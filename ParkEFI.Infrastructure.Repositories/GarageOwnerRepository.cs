using Microsoft.EntityFrameworkCore;
using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using ParkEFI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Infrastructure.Repositories
{
    public class GarageOwnerRepository : GenericRepository<GarageOwnerEntity>, IGarageOwnerRepository
    {
        public GarageOwnerRepository(ParkEFIDbContext db) : base(db)
        {
        }

        public async Task CreateGarageOwnerWithUser(GarageOwnerEntity garageOwner, UserEntity user)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            await _db.GarageOwners.AddAsync(garageOwner);
            await _db.SaveChangesAsync();
            user.SetForeignKeyOfPerson(garageOwner.Id);
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task<GarageOwnerEntity> GetGarageOwnerByIdAsync(int garageOwnerId)
        {
            var garageOwner = await _db.GarageOwners
                .Where(g => g.Id == garageOwnerId)
                .FirstOrDefaultAsync();

            return garageOwner;
        }
    }
}
