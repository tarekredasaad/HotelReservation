namespace HotelReservationApi.Models
{
    public class Booking :BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
