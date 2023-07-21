using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Entities.Enums
{
    public enum ParkingTypes
    {
        PrivateParking,
        HomeGarage
    }

    public enum InfraestructureTypes
    {
        Edifice,
        Lot
    }

    public enum PersonTypes
    {
        Administrator,
        Driver,
        GarageOwner,
        ParkingOwner,
        ParkingSupervisor
    }

    public enum UserNameTypes
    {
        Email,
        PhoneNumber,
        Account
    }

    public enum ParkingOwnerTypes
    {
        ParkingOwner,
        CompanyOwner
    }
}
