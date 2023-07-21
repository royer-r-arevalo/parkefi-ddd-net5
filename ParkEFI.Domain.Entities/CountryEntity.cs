using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class CountryEntity
    {
        private readonly int _countryId;
        private string _name;
        private EntityStatus _status;
        private readonly DateTime _dateRegister;

        private readonly List<CityEntity> _cities;
        private readonly List<ParkingBaseEntity> _parkings;

        public CountryEntity()
        {
        }

        public CountryEntity(int countryId)
        {
            _countryId = countryId;
        }

        public CountryEntity(string name)
        {
            _countryId = 0;
            _name = name;
            _status = EntityStatus.Active;
            _dateRegister = DateTime.Now;
            _cities = new List<CityEntity>();
        }

        public int CountryId => _countryId;
        public string Name { get => _name; private set => _name = value; }
        public EntityStatus Status { get => _status; internal set => _status = value; }
        public DateTime DateRegister => _dateRegister;

        public IReadOnlyList<CityEntity> Cities => _cities;
        public IReadOnlyList<ParkingBaseEntity> Parkings => _parkings;

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
