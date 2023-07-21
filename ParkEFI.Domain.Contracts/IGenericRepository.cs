using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<IList<Entity>> GetAllAsync();
        Task<bool> CreateAsync(Entity entity);
        Task<bool> EditAsync(Entity entity);
        Task<bool> SaveAsync();
    }
}
