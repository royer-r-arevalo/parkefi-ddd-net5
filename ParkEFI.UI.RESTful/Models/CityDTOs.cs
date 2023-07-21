using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public class CityDTO
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public int CountryId { get; set; }
    }

    public class CityCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

    public class CityEditDTO
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
