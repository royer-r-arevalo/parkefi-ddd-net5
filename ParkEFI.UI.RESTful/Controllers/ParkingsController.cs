using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkEFI.Application.Contracts;
using ParkEFI.Domain.Entities;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingService _parkingService;
        private readonly IMapper _mapper;

        public ParkingsController(IParkingService parkingService, IMapper mapper)
        {
            _parkingService = parkingService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateParking")]
        public async Task<IActionResult> CreateParkingAsync([FromBody] ParkingCreateDTO createDTO)
        {
            var parking = _mapper.Map<ParkingEntity>(createDTO);
            await _parkingService.CreateParkingAsync(parking);
            var parkingDTO = _mapper.Map<ParkingDTO>(parking);

            return new CreatedAtRouteResult("GetParking", new { id = parkingDTO.ParkingId }, parkingDTO);
        }

        [HttpGet]
        [Route("GetParking/{id}", Name = "GetParking")]
        public async Task<IActionResult> GetParkingAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var parking = await _parkingService.GetParkingByIdAsync(id.Value);
            if (parking == null)
            {
                return NotFound();
            }
            var parkingDTO = _mapper.Map<ParkingDTO>(parking);
            return Ok(parkingDTO);
        }
    }
}
