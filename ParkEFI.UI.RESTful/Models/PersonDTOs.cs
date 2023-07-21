using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public abstract class PersonDTO
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
}
