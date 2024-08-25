using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Models
{
    public class Reservation : BaseModel
    {
        //public int CustomerId { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string PaymentIntentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double TotalAmount { get; set; }

        public List<RoomReservation> RoomReservations { get; set; }
    }
}
