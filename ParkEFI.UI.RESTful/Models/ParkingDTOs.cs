using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public class ParkingDTO
    {
        public int ParkingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public string InfraestructureType { get; set; }
        public PointDTO Point { get; set; }
        public CountryDTO Country { get; set; }
        public CityDTO City { get; set; }
        public ProvinceDTO Province { get; set; }
        public bool IsDisabled { get; set; }
    }

    public class ParkingCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string PostalCode { get; set; }

        [Required]
        public string InfrastructureType { get; set; }

        public PointCreateDTO Point { get; set; }

        [Required]
        public int CountryId { get; set; }

        public int? CityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? ParkingOwnerId { get; set; }
        public int? CompanyId { get; set; }
    }
}
