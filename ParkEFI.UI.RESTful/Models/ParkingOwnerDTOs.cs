using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Models
{
    public class ParkingOwnerDTO : PersonDTO
    {
        public int ParkingOwnerId { get; set; }
    }
}
