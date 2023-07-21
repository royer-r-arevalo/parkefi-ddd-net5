using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public class UserEntity
    {
        private readonly int _userId;
        private string _userName;
        private readonly DateTime _dateRegister;
        private EntityStatus _status;

        private int _personOfUserId;
        private readonly PersonEntity _person; 

        public UserEntity()
        {
        }

        public UserEntity(string userName)
        {
            _userName = userName;
            _dateRegister = DateTime.Now;
            _status = EntityStatus.Active;
        }

        public UserEntity(string userName, int personId)
        {
            _userName = userName;
            _dateRegister = DateTime.Now;
            _status = EntityStatus.Active;
            _personOfUserId = personId;
        }

        public UserEntity(string userName, PersonEntity person)
        {
            _userName = userName;
            _dateRegister = DateTime.Now;
            _status = EntityStatus.Active;
            _personOfUserId = person.Id;
        }

        public int UserId => _userId;

        public string UserName { get => _userName; private set => _userName = value; }
        public DateTime DateRegister => _dateRegister;

        public EntityStatus Status { get => _status; internal set => _status = value; }

        public PersonEntity Person => _person;

        public int PersonOfUserId { get => _personOfUserId; private set => _personOfUserId = value; }

        public void SetForeignKeyOfPerson(int personId)
        {
            PersonOfUserId = personId;
        }

    }
}
