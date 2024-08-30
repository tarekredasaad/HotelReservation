using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
       
        public HashSet<ReservationFacilityDTO> ReservationFacilities { get; set; }
    }
}
