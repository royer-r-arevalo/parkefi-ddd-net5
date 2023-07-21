using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class PointEntity
    {
        private readonly int _pointId;
        private decimal _latitude;
        private decimal _longitude;

        private int _parkingBaseId;
        private readonly ParkingBaseEntity _parkingBase;

        public PointEntity()
        {
        }

        public PointEntity(decimal latitude, decimal longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        public PointEntity(decimal latitude, decimal longitude, int parkingBaseId)
        {
            _latitude = latitude;
            _longitude = longitude;
            _parkingBaseId = parkingBaseId;
        }

        public int PointId => _pointId;

        public decimal Latitude { get => _latitude; private set => _latitude = value; }
        public decimal Longitude { get => _longitude; private set => _longitude = value; }

        public int ParkingBaseId { get => _parkingBaseId; private set => _parkingBaseId = value; }
        public ParkingBaseEntity ParkingBase => _parkingBase;

        public void SetForeignKeyOfParkingBase(int parkingBaseId)
        {
            ParkingBaseId = parkingBaseId;
        }

    }
}
