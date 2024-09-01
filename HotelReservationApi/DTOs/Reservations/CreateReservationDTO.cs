namespace HotelReservationApi.DTOs.Reservations
{
    public class CreateReservationDTO
    {
        
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsConfirmed => false;

    }
}
