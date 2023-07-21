using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class GarageEntity : ParkingBaseEntity
    {
        private string _electricityBill;
        private readonly GarageOwnerEntity _garageOwner;

        public GarageEntity()
        {
        }

        public GarageEntity(string electricityBill, string description, string postalCode, PointEntity point, CountryEntity country = null, CityEntity city = null, ProvinceEntity province = null)
           : base(description, postalCode, ParkingTypes.HomeGarage, point, country, city, province)
        {
            _electricityBill = electricityBill;
            _garageOwner = new GarageOwnerEntity();
        }

        public string ElectricityBill { get => _electricityBill; private set => _electricityBill = value; }

        public GarageOwnerEntity GarageOwner => _garageOwner;
    }
}
