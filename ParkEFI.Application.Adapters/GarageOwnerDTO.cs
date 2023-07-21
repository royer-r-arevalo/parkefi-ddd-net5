using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Adapters
{
    public class GarageOwnerDTO : PersonBaseDTO
    {
        public int GarageOwnerId { get; set; }
    }

    public class GarageOwnerCreateDTO : PersonCreateBaseDTO
    {

    }
}
