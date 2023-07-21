using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Entities
{
    public class GarageOwnerEntity : PersonEntity
    {
        private readonly List<GarageEntity> _garages;

        public GarageOwnerEntity()
        {
        }   

        public GarageOwnerEntity(string names, string firstSurname, string secondSurname, DateTime birthDate, string email, string phoneNumber, string cedula, Genders gender, UserEntity user)
            : base(names, firstSurname, secondSurname, birthDate, email, phoneNumber, cedula, gender, PersonTypes.GarageOwner, user)
        {
            
        }

        public IReadOnlyList<GarageEntity> Garages => _garages;
    }
}
