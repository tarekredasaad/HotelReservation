using HotelReservationApi.Models;

namespace HotelReservationApi.DTOs.RoomReservationDTO
{
    public class RoomReservationDTO
    {
       public Reservation Reservation { get; set; }
        public HashSet<RoomFacilityDTO> RoomFacilityDTO { get; set; }
    }
}
