using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1NET
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            9) Develop a data structure to store reservation information
            hotel rooms. The number has the following characteristics: class, number of seats
            accommodation, additional options: air conditioner, children's bed, etc. Customers
            book rooms of a certain type for a period(from date to date).
            Assume that one and the same customer can make several reservations
            numbers for the same period, or different numbers for different periods.
            */

            Console.WriteLine("Welcome to my lab! \nAuthor: Dmytro Zhmailo, Group: IP-13 \nVariant: 9");

            /*
             * This code segment shows data initialization
             */

            List<Hotel>hotels = new List<Hotel>();
            hotels.Add(new Hotel(1, "Boguslavka", "Boguslav, st. Ivanivska, 12"));

            List<HotelRoom> hotelRooms = new List<HotelRoom>();

            hotelRooms.Add(new HotelRoom(1, 2, RoomType.Standard, false, true, false, hotels[0].Id));
            hotelRooms.Add(new HotelRoom(2, 5, RoomType.Standard, true, false, false, hotels[0].Id));

            hotelRooms.Add(new HotelRoom(3, 4, RoomType.Superior, true, true, false, hotels[0].Id));
            hotelRooms.Add(new HotelRoom(4, 5, RoomType.Superior, true, true, false, hotels[0].Id));
            hotelRooms.Add(new HotelRoom(5, 3, RoomType.Superior, true, false, false, hotels[0].Id));

            hotelRooms.Add(new HotelRoom(6, 6, RoomType.Suite, true, true, true, hotels[0].Id));

            List<Client> clients = new List<Client>();

            clients.Add(new Client(1, "Boyko", "Marta", new DateTime(1993, 1, 4), "AX012123"));
            clients.Add(new Client(2, "Galushko", "Sergiy", new DateTime(1989, 12, 11), "AX645645"));
            clients.Add(new Client(3, "Kovalenko", "Oleksandr", new DateTime(2001, 2, 25), "DX353432"));
            clients.Add(new Client(4, "Bondarenko", "Denys", new DateTime(2001, 7, 14), "FX376982"));
            clients.Add(new Client(5, "Chayka", "Dmytro", new DateTime(1998, 3, 17), "KX372533"));
            clients.Add(new Client(6, "Siruk", "Volodymyr", new DateTime(1998, 5, 12), "LX234432"));

            List<Booking> bookings = new List<Booking>();

            bookings.Add(new Booking(1, new DateTime(2023, 03, 26), new DateTime(2023, 03, 28)));
            bookings.Add(new Booking(2, new DateTime(2023, 03, 28), new DateTime(2023, 03, 30)));
            bookings.Add(new Booking(3, new DateTime(2023, 03, 24), new DateTime(2023, 03, 25)));
            bookings.Add(new Booking(4, new DateTime(2023, 03, 27), new DateTime(2023, 03, 31)));
            bookings.Add(new Booking(5, new DateTime(2025, 03, 26), new DateTime(2025, 03, 31)));
            bookings.Add(new Booking(6, new DateTime(2023, 03, 14), new DateTime(2023, 03, 19)));
            bookings.Add(new Booking(7, new DateTime(2023, 11, 15), new DateTime(2023, 11, 18)));

            List<ManyToMany> bookingToRooms = new List<ManyToMany>();

            bookingToRooms.Add(new ManyToMany(bookings[0].Id, hotelRooms[0].Id));
            bookingToRooms.Add(new ManyToMany(bookings[1].Id, hotelRooms[1].Id));
            bookingToRooms.Add(new ManyToMany(bookings[2].Id, hotelRooms[1].Id));
            bookingToRooms.Add(new ManyToMany(bookings[2].Id, hotelRooms[2].Id));
            bookingToRooms.Add(new ManyToMany(bookings[3].Id, hotelRooms[3].Id));
            bookingToRooms.Add(new ManyToMany(bookings[4].Id, hotelRooms[4].Id));
            bookingToRooms.Add(new ManyToMany(bookings[4].Id, hotelRooms[5].Id));
            bookingToRooms.Add(new ManyToMany(bookings[5].Id, hotelRooms[2].Id));
            bookingToRooms.Add(new ManyToMany(bookings[6].Id, hotelRooms[0].Id));

            List<ManyToMany> clientToBookings = new List<ManyToMany>();

            clientToBookings.Add(new ManyToMany(clients[0].Id, bookings[0].Id));
            clientToBookings.Add(new ManyToMany(clients[1].Id, bookings[1].Id));
            clientToBookings.Add(new ManyToMany(clients[2].Id, bookings[2].Id));
            clientToBookings.Add(new ManyToMany(clients[3].Id, bookings[3].Id));
            clientToBookings.Add(new ManyToMany(clients[4].Id, bookings[4].Id));
            clientToBookings.Add(new ManyToMany(clients[5].Id, bookings[5].Id));
            clientToBookings.Add(new ManyToMany(clients[5].Id, bookings[6].Id));

            /*
             * This code segment shows the process of creating queries
             */

            Console.WriteLine("\nQueries:");

            // Display all hotel customers and sort them alphabetically by last name and first name

            Console.WriteLine("\n Query 1:");
            var query1 = from c in clients 
            orderby c._surname, c._firstName
             select c._surname + " " + c._firstName;

            foreach (var client in query1) Console.WriteLine($"\t{client}");

            // Show grouped available room types and room ids that have those types

            Console.WriteLine("\n Query 2:");
            var query2 = from r in hotelRooms
            group r by r._type into t 
            select new { key = t.Key, values =  t};


            foreach (var room in query2)
            { 
                Console.Write($"\t{room.key} id: ");
                foreach (var val in room.values)
                    Console.Write($"\t{val.Id}");
                Console.WriteLine();
            }

            // Show names of clients over 27 years old

            Console.WriteLine("\n Query 3:");
            var query3 = from c in clients
            let minAge = 27
            let age = DateTime.Now.Year - c._dateOfBirth.Year
            where age > minAge
            select new { key = c._surname + " " + c._firstName, value = age};

            foreach (var client in query3) 
                Console.WriteLine($"\t{client.key}, age: {client.value}");

            // Calculate the number of rooms with air conditioning and a cot

            Console.WriteLine("\n Query 4:");
            var query4 = (from r in hotelRooms
                          where r._hasConditioner && r._hasCot
                          select r.Id).Count();
            Console.WriteLine($"\tNumber of rooms with conditioner and cot: {query4}");

            // Show the name of the clients who booked the suite

            Console.WriteLine("\n Query 5:");
            var query5 = from c in clients
                         where (from ctb in clientToBookings
                                where
                                (from btr in bookingToRooms
                                 where (from r in hotelRooms where Enum.Equals(RoomType.Suite, r._type) select r.Id)
                                 .Contains(btr.rightId)
                                 select btr.leftId).Contains(ctb.rightId)
                                select ctb.leftId).Contains(c.Id)
                         select c._surname + " " + c._firstName; 

            foreach (var client in query5) Console.WriteLine($"\t{client}");

            // Show the name of clients who booked a room for more than 3 days
            

                        Console.WriteLine("\n Query 6:");
            var query6 = from c in clients
                         let minDays = 3
                         where (from ctb in clientToBookings
                                where
                                (from b in bookings where (b._checkOutDate - b._checkInDate).Days > minDays select b.Id).Contains(ctb.rightId)
                                select ctb.leftId).Contains(c.Id)
                         select c._surname + " " + c._firstName;

            foreach (var client in query6) Console.WriteLine($"\t{client}");

            // Show booking number and client name

            Console.WriteLine("\n Query 7:");
            var query7 = from c in clients join clToB in clientToBookings on c.Id equals clToB.leftId select new {key = c, value = clToB.leftId};

            foreach (var client in query7) Console.WriteLine($"\tbooking №{client.value}, client: {client.key._firstName + " " + client.key._surname}");

            // Show the name of clients grouped by their year of birth 

            Console.WriteLine("\n Query 8:");
            var query8 = from c in clients
                         group c by c._dateOfBirth.Year into y
                         select new { key = y.Key, values = y };

            foreach (var client in query8)
            {
                Console.Write($"\t{client.key} y.o.b. clients: ");
                foreach (var val in client.values)
                    Console.Write($"\t{val._surname + " " + val._firstName};");
                Console.WriteLine();
            }

            // Show bookings grouped by day and month of check-in

            Console.WriteLine("\n Query 9:");
            var query9 = from b in bookings 
            group b by new { b._checkInDate.Day, b._checkInDate.Month } into time 
                         select new { day = time.Key.Day, month = time.Key.Month, book = time.ToList() };

            foreach (var book in query9)
            {
                Console.Write($"\t{book.day}, {book.month} dates: ");
                foreach (var val in book.book)
                    Console.Write($"\t{val._checkInDate} {val._checkOutDate};");
                Console.WriteLine();
            }

            // Creating a temporary list to a client with one duplicate and Concat with clients list

            Console.WriteLine("\n Query 10:");

            List<Client> tempClients = new List<Client>();
            tempClients.Add(new Client(1, "Boyko", "Marta", new DateTime(1993, 1, 4), "AX012123"));
            tempClients.Add(new Client(9, "Stys", "Vasyl", new DateTime(1938, 1, 6), "STUS"));
            tempClients.Add(new Client(10, "Symonenko", "Vasyl", new DateTime(1935, 1, 8), "SYMONENKO"));

            var query10 = (from c in clients select c).Concat(tempClients).ToList();

            foreach (var client in query10)
            {
                Console.WriteLine($"\t{client.Id}, {client._surname} {client._firstName}");
            }

            // Checking the correctness of the entered dates: the date of check-in must not be earlier than the date of check-out

            Console.WriteLine("\n Query 11:");

            var query11 = bookings.All(b => b._checkOutDate >= b._checkInDate);
            Console.WriteLine($"\tAre all dates in booking correct? {query11}");

            // Find the value of the maximum room capacity

            Console.WriteLine("\n Query 12:");

            var query12 = hotelRooms.Max(h => h._roomCapacity);
            Console.WriteLine($"\tMax room capacity is: {query12}");

            // Display the IDs of rooms that have cots and sort them by room capacity

            Console.WriteLine("\n Query 13:");
            var query13 = (from r in hotelRooms where r._hasCot select r).OrderBy(h => h._roomCapacity);

            foreach (var room in query13)
            {
                Console.WriteLine($"\tRoom id: {room.Id}, capacity: {room._roomCapacity}, type: {room._type}; has cot: {room._hasCot}");
            }

            // Use the Cartesian product to show the location and name of the hotel for all its rooms
            
            Console.WriteLine("\n Query 14:");
            var query14 = from r in hotelRooms
                          from h in hotels
                          select new { hotel = h._name, location = h._location, type = r._type, capacity = r._roomCapacity };

            foreach (var room in query14)
            {
                Console.WriteLine($"\tHotel: {room.hotel}\tlocation: {room.location}\troom: {room.type}\tcapacity: {room.capacity}");
            }

            // Group bookings by their clients and show the total number of bookings of these clients

            Console.WriteLine("\n Query 15:");
            var query15 = from ctb in clientToBookings
                          group ctb by ctb.leftId into t
                          orderby t.Key descending
                          join c in clients on t.Key equals c.Id
                          select new { key = c, value = t.Count() };

            foreach (var booking in query15)
            {
                Console.WriteLine($"\tClient's name and surname: {booking.key._firstName + " " + booking.key._surname}\tNumber of bookings: {booking.value}");
            }

            // Find customer names with passport series "AX"

            Console.WriteLine("\n Query 16:");
            var query16 = from c in clients
                          where c._passportCode.StartsWith("AX")
                          select c;

            foreach (var client in query16)
            {
                Console.WriteLine($"\t{client._passportCode}\t{client._firstName}");
            }

            // Calculate the average number of days for booking

            Console.WriteLine("\n Query 17:");
            var query17 = bookings.Select(d => (d._checkOutDate - d._checkInDate).Days).Average();

            Console.WriteLine($"\tAverage number of days spent: {Math.Round(query17, 3)}");

            // Count the number of rooms that have air conditioning

            Console.WriteLine("\n Query 18:");
            var query18 = from r in hotelRooms
                         group r by r._hasConditioner into t
                         select new { key = t.Key, value = t.Count() };

            foreach (var room in query18)
            {
                Console.WriteLine($"\tHas conditioner? {room.key}, count: {room.value}");
            }

            // Find out if there is a booking for a year in advance

            Console.WriteLine("\n Query 19:");
            var query19 = bookings.Any(d => d._checkInDate > DateTime.Now.AddYears(1));

            Console.WriteLine($"\tIs there any dates, that has check ins after a year from now? {query19}");

            // Show the day of week of check-in, the day of week of check-out, the type of room,
            // its capacity and the person who booked the room for all bookings

            Console.WriteLine("\n Query 20:");
            var query20 = from btr in bookingToRooms
                          join b in bookings on btr.leftId equals b.Id
                          join r in hotelRooms on btr.rightId equals r.Id
                          join ctb in clientToBookings on btr.leftId equals ctb.rightId
                          join c in clients on ctb.leftId equals c.Id
                          select new
                          {
                              checkIn = b._checkInDate,
                              checkOut = b._checkOutDate,
                              type = r._type,
                              capacity = r._roomCapacity,
                              client = c._surname + " " + c._firstName
                          };

            foreach (var booking in query20)
            {
                Console.WriteLine($"\tCheck In: {booking.checkIn.DayOfWeek}\tCheckout: {booking.checkOut.DayOfWeek}" +
                    $"\troom: {booking.type}\tCap: {booking.capacity}\tClient: {booking.client}");
            }
        }
    }
}