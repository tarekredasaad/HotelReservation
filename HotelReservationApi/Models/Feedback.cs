namespace HotelReservationApi.Models
{
    public class Feedback : BaseModel
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public List<FeedbackResponse> Responses { get; set; }
    }
}
