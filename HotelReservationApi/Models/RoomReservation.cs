using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Models
{
    public class RoomReservation : BaseModel
    {
        public int RoomId { get; set; } 
        public Room Room { get; set; }
        
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
