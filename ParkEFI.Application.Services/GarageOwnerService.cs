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
    public class GarageOwnerService : IGarageOwnerService
    {
        private readonly IGarageOwnerRepository _garageOwnerRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public GarageOwnerService(IGarageOwnerRepository garageOwnerRepository, IUserRepository userRepository, ILogger<GarageOwnerService> logger)
        {
            _garageOwnerRepository = garageOwnerRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<GarageOwnerEntity> CreateGarageOwnerAsync(GarageOwnerEntity garageOwner)
        {
            await _garageOwnerRepository.CreateAsync(garageOwner);
            return garageOwner;
        }

        public async Task CreateGarageOwnerWithUserAsync(GarageOwnerEntity garageOwner, UserEntity user)
        {
            await _garageOwnerRepository.CreateGarageOwnerWithUser(garageOwner, user);
        }
    }
}
