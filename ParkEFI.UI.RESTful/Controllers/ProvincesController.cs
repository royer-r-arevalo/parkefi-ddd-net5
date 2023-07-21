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
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProvincesController(IProvinceService provinceService, IMapper mapper, ILogger<ProvincesController> logger)
        {
            _provinceService = provinceService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetProvincesByCity/{cityId}")]
        public async Task<IActionResult> GetProvincesByCityAsync(int? cityId)
        {
            if (cityId == null)
            {
                return BadRequest();
            }
            var provinces = await _provinceService.GetProvincesByCityIdAsync(cityId.Value);
            var provincesDTO = _mapper.Map<IList<ProvinceDTO>>(provinces);
            return Ok(provincesDTO);
        }
    }
}
