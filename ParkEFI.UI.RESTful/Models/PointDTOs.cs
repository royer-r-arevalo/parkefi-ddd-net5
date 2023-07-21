using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public class PointDTO
    {
        public int PointId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class PointCreateDTO
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
