using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ParkEFI.UI.RESTful.Models;
using ParkEFI.Application.Contracts;

namespace ParkEFI.UI.RESTful.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CountriesController(ICountryService countryService, IMapper mapper, ILogger<CountriesController> logger)
        {
            _countryService = countryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            var countriesDTO = _mapper.Map<IList<CountryDTO>>(countries);
            return Ok(countriesDTO);
        }
    }
}
