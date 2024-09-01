namespace HotelReservationApi.DTOs.FeedbackResponses
{
    public class FeedbackResponseDTO
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string ResponseText { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
