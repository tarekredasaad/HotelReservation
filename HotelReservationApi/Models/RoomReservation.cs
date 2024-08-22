using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Models
{
    public class RoomReservation : BaseModel
    {
        public double TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
     
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int RoomId { get; set; } 
        public Room Room { get; set; }
        
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
