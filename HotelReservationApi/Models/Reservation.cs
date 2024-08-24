namespace HotelReservationApi.Models
{
    public class Reservation : BaseModel
    {
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsConfirmed { get; set; }
        public List<RoomReservation> RoomReservations { get; set; }
    }
}
