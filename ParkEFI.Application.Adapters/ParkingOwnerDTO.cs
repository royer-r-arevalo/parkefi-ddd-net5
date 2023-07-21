using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Adapters
{
    public class ParkingOwnerDTO : PersonBaseDTO
    {
        public int ParkingOwnerId { get; set; }
    }

    public class ParkingOwnerCreateDTO : PersonCreateBaseDTO
    {
        
    }
}
