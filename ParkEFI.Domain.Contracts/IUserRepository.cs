using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Contracts
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
    }
}
