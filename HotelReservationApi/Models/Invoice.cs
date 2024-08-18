using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Models
{
    public class Invoice : BaseModel
    {
        public double Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentType PaymentType { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}
