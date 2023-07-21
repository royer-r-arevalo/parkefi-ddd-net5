using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginInfoDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserName { get; set; }
    }
}
