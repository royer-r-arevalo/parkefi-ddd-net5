using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Entities
{
    public class ParkingOwnerEntity : PersonEntity
    {
        private ParkingOwnerTypes _parkingOwnerType;

        private readonly List<ParkingEntity> _parkings; 
        private readonly List<CompanyEntity> _companies;

        public ParkingOwnerEntity()
        {
        }

        public ParkingOwnerEntity(string names, string firstSurname, string secondSurname, DateTime birthDate, string email, string phoneNumber, string cedula, Genders gender, UserEntity user)
             : base(names, firstSurname, secondSurname, birthDate, email, phoneNumber, cedula, gender, PersonTypes.ParkingOwner, user)
        {
            _parkingOwnerType = ParkingOwnerTypes.ParkingOwner;
            _companies = new List<CompanyEntity>();
        }

        public ParkingOwnerTypes ParkingOwnerType { get => _parkingOwnerType; internal set => _parkingOwnerType = value; }
        public IReadOnlyList<CompanyEntity> Companies => _companies;
        public IReadOnlyList<ParkingEntity> Parkings => _parkings;
    }
}