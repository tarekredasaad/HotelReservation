using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Pictures;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public double Price { get; set; }

        public List<PictureDTO> Pictures { get; set; }
        public HashSet<FacilityDTO> Facilities { get; set; }
    }
}
