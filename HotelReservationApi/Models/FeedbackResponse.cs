namespace HotelReservationApi.Models
{
    public class FeedbackResponse : BaseModel
    {
        public string Text { get; set; }
        public DateTime ResponseDate { get; set; }

        public int FeedbackId { get; set; }
        public Feedback Feedback { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
