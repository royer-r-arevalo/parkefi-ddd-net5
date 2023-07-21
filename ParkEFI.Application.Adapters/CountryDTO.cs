using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Adapters
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
    }

    public class CountryCreateDTO
    {
        public string Name { get; set; }
    }

    public class CountryEditDTO
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
