using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Domain.Entities.Enums;

namespace ParkEFI.Domain.Entities
{
    public abstract class PersonEntity
    {
        private readonly int _id;
        private string _names;
        private string _firstSurname;
        private string _secondSurname;
        private DateTime _birthDate;
        private string _email;
        private string _phoneNumber;
        private string _cedula;
        private Genders _gender;
        private PersonTypes _persontype;
        private EntityStatus _status;
        private readonly DateTime _dateRegister;

        private readonly UserEntity _user;

        public PersonEntity()
        {
        }

        public PersonEntity(string names, string firstSurname, string secondSurname, DateTime birthDate, string email, string phoneNumber, string cedula, Genders gender, PersonTypes personType)
        {
            _names = names;
            _firstSurname = firstSurname;
            _secondSurname = secondSurname;
            _birthDate = birthDate;
            _email = email;
            _phoneNumber = phoneNumber;
            _cedula = cedula;
            _gender = gender;
            _persontype = personType;
            _status = EntityStatus.Active;
            _dateRegister = DateTime.Now;
        }

        public PersonEntity(string names, string firstSurname, string secondSurname, DateTime birthDate, string email, string phoneNumber, string cedula, Genders gender, PersonTypes personType, UserEntity user)
        {
            _names = names;
            _firstSurname = firstSurname;
            _secondSurname = secondSurname;
            _birthDate = birthDate;
            _email = email;
            _phoneNumber = phoneNumber;
            _cedula = cedula;
            _gender = gender;
            _persontype = personType;
            _status = EntityStatus.Active;
            _dateRegister = DateTime.Now;
            _user = user;
        }

        public int Id => _id;

        public string Names { get => _names; private set => _names = value; }
        public string FirstSurname { get => _firstSurname; private set => _firstSurname = value; }
        public string SecondSurname { get => _secondSurname; private set => _secondSurname = value; }
        public DateTime BirthDate { get => _birthDate; private set => _birthDate = value; }
        public string Email { get => _email; private set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; private set => _phoneNumber = value; }
        public string Cedula { get => _cedula; private set => _cedula = value; }
        public Genders Gender { get => _gender; internal set => _gender = value; }
        public PersonTypes Persontype { get => _persontype; internal set => _persontype = value; }
        public EntityStatus Status { get => _status; internal set => _status = value; }
        public DateTime DateRegister => _dateRegister;
        
        public UserEntity User => _user;
    }
}
