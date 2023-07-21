using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ParkEFI.Crosscutting.Identity.Adapters;
using ParkEFI.Crosscutting.Identity.Contracts;
using ParkEFI.Crosscutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Crosscutting.Identity.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger _logger;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ILogger<ApplicationUserService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<ApplicationUser> LoginAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password, ApplicationRole role)
        {
            var userResult = await _userManager.CreateAsync(user, password);
            if (userResult.Succeeded)
            {
                var roleSearch = await _roleManager.FindByNameAsync(role.Name);
                if (roleSearch == null)
                {
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception();
                    }
                }
                var assignmentResult = await _userManager.AddToRoleAsync(user, role.Name);
                if (!assignmentResult.Succeeded)
                {
                    throw new Exception();
                }
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser> FindUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user ?? null;
        }

        public async Task<ApplicationUser> FindUserByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user ?? null;
        }

        public async Task<IList<ApplicationRole>> GetUserRolesAsync(ApplicationUser user)
        {
            var roleNames = await _userManager.GetRolesAsync(user);
            var roles = new List<ApplicationRole>();
            foreach (string name in roleNames)
            {
                roles.Add(new ApplicationRole
                {
                    Name = name
                });
            }
            return roles;
        }

        public async Task<bool> UserExistsAsync(string userName = null, string userId = null, string email = null)
        {
            ApplicationUser user = null;
            if (!string.IsNullOrEmpty(userName))
            {
                user = await _userManager.FindByNameAsync(userName);
            }
            else if (!string.IsNullOrEmpty(userId))
            {
                user = await _userManager.FindByIdAsync(userId);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                user = await _userManager.FindByEmailAsync(email);
            }

            return user != null;
        }

        public async Task<IList<Claim>> GetAuthClaimsAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            return authClaims;
        }
    }
}
