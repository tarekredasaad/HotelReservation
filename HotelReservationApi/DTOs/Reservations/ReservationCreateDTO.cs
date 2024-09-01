using HotelReservationApi.DTOs.RoomReservations;

namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationCreateDTO
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public List<RoomReservationCreateDTO> RoomReservations { get; set; }
    }
}
