using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class ProvinceEntity
    {
        private readonly int _provinceId;
        private string _name;
        private EntityStatus _status;
        private readonly DateTime _dateRegister;

        private CityEntity _city;
        private readonly List<ParkingBaseEntity> _parkings;

        public ProvinceEntity()
        {
        }

        public ProvinceEntity(int provinceId)
        {
            _provinceId = provinceId;
        }

        public ProvinceEntity(string name, CityEntity city)
        {
            _provinceId = 0;
            _name = name;
            _status = EntityStatus.Active;
            _dateRegister = DateTime.Now;
            _city = city;
        }

        public int ProvinceId => _provinceId;
        public string Name { get => _name; private set => _name = value; }
        public EntityStatus Status { get => _status; internal set => _status = value; }
        public DateTime DateRegister => _dateRegister;

        public CityEntity City { get => _city; private set => _city = value; }
        public IReadOnlyList<ParkingBaseEntity> Parkings => _parkings;

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeCity(CityEntity city)
        {
            City = city;
        }
    }
}
