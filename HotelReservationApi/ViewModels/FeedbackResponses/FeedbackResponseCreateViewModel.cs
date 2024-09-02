namespace HotelReservationApi.ViewModels.FeedbackResponses
{
    public class FeedbackResponseCreateViewModel
    {
        public int FeedbackId { get; set; }
        public int StaffId { get; set; }
        public string ResponseText { get; set; }
    }
}
