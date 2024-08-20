namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationDTO
    {
        public HashSet<int> Rooms { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
