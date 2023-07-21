﻿using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Contracts
{
    public interface IUserService
    {
        Task<UserEntity> CreateUserAsync(UserEntity user);
    }
}
