using HotelReservationApi.Models;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomCreateDTO
    {
        public string name { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public double Price { get; set; }

    }
}
