using ParkEFI.Crosscutting.Identity.Models;
using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{

    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public bool UserNameConfirmed { get; set; }
    }

    public class UserCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Names { get; set; }

        [Required]
        [MaxLength(50)]
        public string FamilyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string GivenName { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string RoleType { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(15)]
        public string Cedula { get; set; }

        [Required]
        public string UserNameType { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
