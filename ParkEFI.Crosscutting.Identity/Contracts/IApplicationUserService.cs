using ParkEFI.Crosscutting.Identity.Adapters;
using ParkEFI.Crosscutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Crosscutting.Identity.Contracts
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> LoginAsync(string userName, string password);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password, ApplicationRole role);
        Task<ApplicationUser> FindUserByIdAsync(string id);
        Task<ApplicationUser> FindUserByUserNameAsync(string userName);
        Task<IList<ApplicationRole>> GetUserRolesAsync(ApplicationUser user);
        Task<bool> UserExistsAsync(string userName = null, string userId = null, string email = null);
        Task<IList<Claim>> GetAuthClaimsAsync(ApplicationUser user);
    }
}
