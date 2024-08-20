using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomCreateDTO
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }
    }
}
