using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NET
{
    internal class Hotel
    {
        /*
         * The Hotel class represents a hotel and contains information about the hotel, 
         * such as it's name and location. The class has a constructor that initializes
         *  the object with the necessary properties.
         */
        public int Id { get; }
        public string _name { get; }
        public string _location { get; }

        public Hotel(int hotelId, string name, string location)
        {
            Id = hotelId;
            _name = name;
            _location = location;
        }
    }
}
