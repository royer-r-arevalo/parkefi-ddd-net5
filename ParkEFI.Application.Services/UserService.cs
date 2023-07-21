using ParkEFI.Domain.Contracts;
using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Services
{
    public class UserService : Contracts.IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            await _userRepository.CreateAsync(user);
            return user;
        }
    }
}
