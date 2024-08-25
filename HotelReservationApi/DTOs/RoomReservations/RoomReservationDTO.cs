using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.ViewModels.Facilities;

namespace HotelReservationApi.DTOs.RoomReservations
{
    public class RoomReservationDTO
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
        public List<FacilityDTO> Facilities { get; set; }
    }
}
