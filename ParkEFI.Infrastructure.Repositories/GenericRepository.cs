using Microsoft.EntityFrameworkCore;
using ParkEFI.Crosscutting.Utils.Extensions;
using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Infrastructure.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected ParkEFIDbContext _db;

        public GenericRepository(ParkEFIDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Entity>> GetAllAsync()
        {
            return await _db.Set<Entity>().ToListAsync();
        }

        public virtual async Task<bool> CreateAsync(Entity entity)
        {
            await _db.Set<Entity>().AddAsync(entity);
            return await SaveAsync();
        }

        public virtual async Task<bool> EditAsync(Entity entity)
        {
            _db.Set<Entity>().Update(entity);
            return await SaveAsync();
        }

        public virtual async Task<bool> SaveAsync()
        {
            try
            {
                var result = await _db.SaveChangesAsync();
                return result.ToBoolean();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
