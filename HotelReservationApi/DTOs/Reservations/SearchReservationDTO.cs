using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.DTOs.Reservations
{
    public class SearchReservationDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public RoomType Types { get; set; }
        public HashSet<int> RoomIds { get; set; }
    }
}
