namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationDTO
    {
        public HashSet<int> RoomIds { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
