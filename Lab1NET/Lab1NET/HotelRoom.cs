using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NET
{
    internal class HotelRoom
    {
        /*
         * The HotelRoom class represents a room in a hotel and contains information about the hotel room, 
         * such as it's capacity, type, availability of conditioner, cot and minibar in the room. The class has a constructor that initializes
         *  the object with the necessary properties. The RoomType enum is defined to provide 3 options for the type of room: standard, superior and suite.
         *  Each room contains the id of the hotel that owns it.
         */
        public int Id { get; }
        public int _roomCapacity { get; }
        public RoomType _type { get; }
        public bool _hasConditioner { get; }
        public bool _hasCot { get; }
        public bool _hasMinibar { get; }
        
        public int _hotelId { get; }

        public HotelRoom(int hotelRoomId, int roomCapacity, RoomType type, bool hasConditioner, bool hasCot, bool hasMinibar, int hotelId)
        {
            Id = hotelRoomId;
            _roomCapacity = roomCapacity;
            _type = type;
            _hasConditioner = hasConditioner;
            _hasCot = hasCot;
            _hasMinibar = hasMinibar;
            _hotelId = hotelId;
        }
    }

    public enum RoomType
    {
        Standard,
        Superior,
        Suite
    }
}
