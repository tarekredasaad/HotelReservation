using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Facilities;

namespace HotelReservationApi.ViewModels.Rooms
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public double Price { get; set; }

        public List<PictureDTO> Pictures { get; set; }
        public HashSet<FacilityDTO> Facilities { get; set; }
    }
}
