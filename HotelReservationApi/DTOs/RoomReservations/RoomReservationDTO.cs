using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;

namespace HotelReservationApi.DTOs.RoomReservations
{
    public class RoomReservationDTO
    {
        public Reservation Reservation { get; set; }
        public HashSet<ReservationFacilityDTO> ReservationFacilityDTO { get; set; }
    }
}