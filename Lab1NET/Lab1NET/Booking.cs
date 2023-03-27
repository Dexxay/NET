using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NET
{
    internal class Booking
    {
        /*
         * The Booking class represents a hotel room reservation and contains information about the booking,
         * such as check-in time and check-out time. The class has a constructor that initializes
         * the object with the necessary properties.
         */
        public int Id { get; }
        public DateTime _checkInDate { get; }
        public DateTime _checkOutDate { get; }

        public Booking(int bookingId, DateTime checkInDate, DateTime checkOutDate)
        {
            Id = bookingId;
            _checkInDate = checkInDate;
            _checkOutDate = checkOutDate;
        }
    }
}
