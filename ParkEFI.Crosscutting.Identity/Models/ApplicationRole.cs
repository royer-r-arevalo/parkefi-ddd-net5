using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Crosscutting.Identity.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {

    }
   
    public enum RoleTypes
    {
        Administrator,
        Driver,
        GarageOwner,
        ParkingOwner,
        ParkingSupervisor,
    }
}
