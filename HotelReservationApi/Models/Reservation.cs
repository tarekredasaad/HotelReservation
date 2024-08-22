namespace HotelReservationApi.Models
{
    public class Reservation : BaseModel
    {
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }

        public string PaymentIntentId { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public List<RoomReservation> RoomReservations { get; set; }
    }
}
