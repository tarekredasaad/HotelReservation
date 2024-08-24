namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public HashSet<int> Rooms { get; set; }
        public HashSet<int> Facilities { get; set; }



    }
}
