using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Facilities;

namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }

        public List<PictureDTO> Pictures { get; set; }
        public HashSet<FacilityDTO> Facilities { get; set; }
    }
}
