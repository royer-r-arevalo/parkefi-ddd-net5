using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class CityEntity
    {
        private readonly int _cityId;
        private string _name;
        private EntityStatus _status;
        private readonly DateTime _dateRegister;
        
        private CountryEntity _country;
        private readonly List<ProvinceEntity> _provinces;
        private readonly List<ParkingBaseEntity> _parkings;

        public CityEntity()
        {
        }

        public CityEntity(int cityId)
        {
            _cityId = cityId;
        }

        public CityEntity(string name, CountryEntity country)
        {
            _cityId = 0;
            _name = name;
            _status = EntityStatus.Active;
            _dateRegister = DateTime.Now;
            _country = country ?? new CountryEntity();
            _provinces = new List<ProvinceEntity>();
        }

        public int CityId => _cityId;
        public string Name { get => _name; private set => _name = value; }
        public EntityStatus Status { get => _status; internal set => _status = value; }
        public DateTime DateRegister => _dateRegister;
        
        public CountryEntity Country { get => _country; private set => _country = value; }
        public IReadOnlyList<ProvinceEntity> Provinces => _provinces;
        public IReadOnlyList<ParkingBaseEntity> Parkings => _parkings;

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeCountry(CountryEntity country)
        {
            Country = country;
        }
    }
}
