using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomCreateDTO
    {
        public string Number { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public double Price { get; set; }

        public HashSet<int> FacilityIDs { get; set; }
        public List<PictureDTO> Pictures { get; set; }
    }
}
