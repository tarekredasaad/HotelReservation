using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Pictures;

namespace HotelReservationApi.ViewModel.Rooms
{
    public class RoomCreateViewModel
    {
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public double Price { get; set; }

        public HashSet<int> FacilityIDs { get; set; }
        public List<PictureDTO> Pictures { get; set; }
    }
}
