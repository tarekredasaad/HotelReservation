using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs;

namespace HotelReservationApi.ViewModels.Rooms
{
    public class RoomCreateViewModel
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }

        public HashSet<int> FacilityIDs { get; set; }
        public List<PictureDTO> Pictures { get; set; }
    }
}
