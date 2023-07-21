using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public abstract class ParkingBaseEntity
    {
        private readonly int _id;
        private string _description;
        private string _postalCode;
        private ParkingTypes _parkingType;
        private EntityStatus _status;
        private readonly DateTime _dateRegister;

        private readonly CountryEntity _country;
        private readonly CityEntity _city;
        private readonly ProvinceEntity _province;

        private readonly PointEntity _point;

        public ParkingBaseEntity()
        {
        }

        public ParkingBaseEntity(string description, string postalCode, ParkingTypes parkingType, PointEntity point, 
            CountryEntity country = null, CityEntity city = null, ProvinceEntity province = null)
        {
            _description = description;
            _postalCode = postalCode;
            _parkingType = parkingType;
            _status = EntityStatus.Active;
            _dateRegister = DateTime.Now;
            _point = point;

            if (country != null)
            {
                _country = country;
            }
            if (city != null)
            {
                _city = city;
            }
            if (province != null)
            {
                _province = province;
            }
        }

        public int Id => _id;

        public string Description { get => _description; private set => _description = value; }
        public string PostalCode { get => _postalCode; private set => _postalCode = value; }
        public ParkingTypes ParkingType { get => _parkingType; internal set => _parkingType = value; }
        public EntityStatus Status { get => _status; internal set => _status = value; }
        public DateTime DateRegister => _dateRegister;

        public CountryEntity Country => _country;
        public CityEntity City => _city;
        public ProvinceEntity Province => _province;

        public PointEntity Point => _point;
    }
}
