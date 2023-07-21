using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class ParkingEntity : ParkingBaseEntity
    {
        private string _name;
        private InfraestructureTypes _infraestructureType;

        private readonly CompanyEntity _company;
        private readonly ParkingOwnerEntity _parkingOwner;

        public ParkingEntity()
        {
        }

        public ParkingEntity(string name, InfraestructureTypes infraestructureType, 
            string description, string postalCode, PointEntity point, ParkingOwnerEntity parkingOwner = null, 
            CompanyEntity company = null, CountryEntity country = null, CityEntity city = null, ProvinceEntity province = null)
            :base(description, postalCode, ParkingTypes.PrivateParking, point, country, city, province)
        {
            _name = name;
            _infraestructureType = infraestructureType;
            if (parkingOwner != null)
            {
                _parkingOwner = parkingOwner;
            }
            else if (company != null)
            {
                _company = company;
            }
        }

        public string Name { get => _name; private set => _name = value; }
        public InfraestructureTypes InfraestructureType { get => _infraestructureType; internal set => _infraestructureType = value; }

        public CompanyEntity Company => _company;
        public ParkingOwnerEntity ParkingOwner => _parkingOwner;
    }
}
