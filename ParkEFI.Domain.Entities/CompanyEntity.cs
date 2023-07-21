using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Domain.Entities
{
    public class CompanyEntity
    {
        private readonly int _companyId;
        private string _name;
        private string _nit;
        private readonly DateTime _dateRegister;
        private EntityStatus _status;

        private readonly ParkingOwnerEntity _companyOwner;
        private readonly List<ParkingEntity> _parkings;

        public CompanyEntity(int companyId)
        {
            _companyId = companyId;
        }

        public CompanyEntity(string name, string nit, ParkingOwnerEntity companyOwner)
        {
            _name = name;
            _nit = nit;
            _dateRegister = DateTime.Now;
            _status = EntityStatus.Active;
            _companyOwner = companyOwner;
        }

        public int CompanyId => _companyId;

        public string Name { get => _name; private set => _name = value; }
        public string Nit { get => _nit; private set => _nit = value; }
        public DateTime DateRegister => _dateRegister;
        public EntityStatus Status { get => _status; internal set => _status = value; }

        public ParkingOwnerEntity CompanyOwner => _companyOwner;
        public IReadOnlyList<ParkingEntity> Parkings => _parkings;
    }
}
