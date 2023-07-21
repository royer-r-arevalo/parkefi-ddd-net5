using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkEFI.Application.Contracts;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CitiesController(ICityService cityService, IMapper mapper, ILogger<CitiesController> logger)
        {
            _cityService = cityService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCitiesByCountry/{countryId}")]
        public async Task<IActionResult> GetCitiesByCountryAsync(int? countryId)
        {
            if (countryId == null)
            {
                return BadRequest();
            }
            var cities = await _cityService.GetCitiesByCountryIdAsync(countryId.Value);
            var citiesDTO = _mapper.Map<IList<CityDTO>>(cities);
            return Ok(citiesDTO);
        }


        
    }
}
