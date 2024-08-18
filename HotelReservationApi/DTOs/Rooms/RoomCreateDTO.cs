using HotelReservationApi.Constant.Enum;
using HotelReservationApi.Models;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomCreateDTO
    {
        public string name { get; set; }
        public Status Status { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }

    }
}
