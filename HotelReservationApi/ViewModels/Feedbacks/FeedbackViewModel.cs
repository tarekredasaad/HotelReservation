namespace HotelReservationApi.ViewModels.Feedbacks
{
    public class FeedbackViewModel
    {
        public string Comments { get; set; }
        public int Rating { get; set; }
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }
    }
}
