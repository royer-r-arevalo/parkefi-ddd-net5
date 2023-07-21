using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public class ProvinceDTO
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public int CityId { get; set; }
    }

    public class ProvinceCreateDTO
    {
        public string Name { get; set; }
        public int CityId { get; set; }
    }

    public class ProvinceEditDTO
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
