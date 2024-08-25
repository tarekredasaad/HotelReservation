using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Models
{
    public class Payment : BaseModel
    {
        public string PaymentIntentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
    }
}
