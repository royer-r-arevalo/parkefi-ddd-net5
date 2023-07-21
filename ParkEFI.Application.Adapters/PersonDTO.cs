using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Adapters
{
    public abstract class PersonBaseDTO
    {
        public string Names { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDisabled { get; set; }
    }

    public abstract class PersonTypesBaseDTO
    {
        public bool IsGarageOwner { get; set; }
        public bool IsDriver { get; set; }
        public bool IsParkingOwner { get; set; }
        public bool IsParkingSupervisor { get; set; }
    }

    public abstract class PersonCreateBaseDTO : PersonTypesBaseDTO
    {
        public string Names { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string BirthDate { get; set; }
        public bool IsGenderMale { get; set; }
        public bool IsGenderFamale { get; set; }
        public bool IsGenderOther { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    } 
}
