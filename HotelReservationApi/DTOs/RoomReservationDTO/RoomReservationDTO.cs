using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.DTOs.RoomReservationDTO
{
    public class RoomReservationDTO
    {
        public Reservation Reservation { get; set; }
        public HashSet<RoomFacilityDTO> ReservationFacilityDTO { get; set; }
    }
}
