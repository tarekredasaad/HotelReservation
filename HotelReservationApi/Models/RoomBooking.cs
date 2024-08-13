namespace HotelReservationApi.Models
{
    public class RoomBooking:BaseModel
    {
        public int RoomId { get; set; } 
        public Room Room { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int NumberDays { get; set; }
        public double TotalPrice { get; set; }


    }
}
