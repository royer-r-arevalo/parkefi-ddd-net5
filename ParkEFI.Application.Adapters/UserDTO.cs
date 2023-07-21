using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Application.Adapters
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsDisabled { get; set; }
    }

    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public int? GarageOwnerId { get; set; }
        public int? ParkingOwnerId { get; set; }
        public int? DriverId { get; set; }
        public int? ParkingSupervisorId { get; set; }
    }
}
