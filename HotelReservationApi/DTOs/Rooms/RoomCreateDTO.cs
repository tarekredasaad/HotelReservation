using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Pictures;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomCreateDTO
    {
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public double Price { get; set; }

        public HashSet<int> FacilityIDs { get; set; }
        public List<PictureDTO> Pictures { get; set; }
    }
}
