using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NET
{
    internal class Client
    {
        /*
         * The Client class represents a client of hotel and contains information about the customer, such as
         * their first name, surname, date of birth, passport code. The class has a constructor that initializes
         * the object with the necessary properties.
         */

        public int Id { get; }
        public string _surname { get; }
        public string _firstName { get; }
        public DateTime _dateOfBirth { get; }
        public string _passportCode { get; }

        public Client(int clientId, string surname, string firstName, DateTime dateOfBirth, string passportCode)
        {
            Id = clientId;
            _surname = surname;
            _firstName = firstName;
            _dateOfBirth = dateOfBirth;
            _passportCode = passportCode;
        }
    }
}
