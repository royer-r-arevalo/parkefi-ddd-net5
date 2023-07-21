using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Crosscutting.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }

    public enum UserNameTypes
    {
        UserName,
        Email,
        PhoneNumber,
    }
}
