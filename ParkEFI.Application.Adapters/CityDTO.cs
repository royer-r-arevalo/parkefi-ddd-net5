using System;

namespace ParkEFI.Application.Adapters
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
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CityEditDTO
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
