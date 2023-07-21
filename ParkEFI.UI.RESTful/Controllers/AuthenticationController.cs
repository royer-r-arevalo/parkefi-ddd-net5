using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ParkEFI.Application.Contracts;
using ParkEFI.Crosscutting.Identity.Contracts;
using ParkEFI.Crosscutting.Identity.Models;
using ParkEFI.Crosscutting.Utils.Extensions;
using ParkEFI.Domain.Entities;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ParkEFI.UI.RESTful.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IApplicationUserService _appUserService;
        private readonly IGarageOwnerService _garageOwnerService;
        private readonly IParkingOwnerService _parkingOwnerService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticationController(
            IApplicationUserService appUserService,
            IGarageOwnerService garageOwnerService,
            IParkingOwnerService parkingOwnerService,
            IUserService userService,
            IConfiguration configuration,
            IMapper mapper)
        {
            _appUserService = appUserService;
            _garageOwnerService = garageOwnerService;
            _parkingOwnerService = parkingOwnerService;
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var user = await _appUserService.LoginAsync(loginDTO.UserName, loginDTO.Password);
            if (user != null)
            {
                var authClaims = await _appUserService.GetAuthClaimsAsync(user);
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken
                (
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   expires: DateTime.Now.AddHours(3),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new LoginInfoDTO
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    UserName = user.UserName
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("CreateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCreateDTO createDTO)
        {
            bool userExists = await _appUserService.UserExistsAsync(createDTO.UserName);
            if (userExists)
            {
                return BadRequest();
            }

            var appUser = _mapper.Map<ApplicationUser>(createDTO);
            var appRole = _mapper.Map<ApplicationRole>(createDTO);
            await _appUserService.CreateUserAsync(appUser, createDTO.Password, appRole);
            if (appUser == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            switch (createDTO.RoleType.ToEnum<RoleTypes>())
            {
                case RoleTypes.GarageOwner:
                    var garageOwner = _mapper.Map<GarageOwnerEntity>(createDTO);
                    await _garageOwnerService.CreateGarageOwnerAsync(garageOwner);
                    if (garageOwner == null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                    break;
                case RoleTypes.ParkingOwner:
                    var parkingOwner = _mapper.Map<ParkingOwnerEntity>(createDTO);
                    await _parkingOwnerService.CreateParkingOwnerAsync(parkingOwner);
                    if (parkingOwner == null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                    break;
                case RoleTypes.ParkingSupervisor:
                    break;
                case RoleTypes.Driver:
                    break;
                case RoleTypes.Administrator:
                    break;
            }
           
            var userDTO = _mapper.Map<UserDTO>(appUser);
            return new CreatedAtRouteResult("GetUser", new { id = userDTO.Id }, userDTO);
        }

        [HttpGet]
        [Route("GetUser/{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUserAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var appUser = await _appUserService.FindUserByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserDTO>(appUser);
            return Ok(userDTO);
        }
    }
}
