using HotelReservationApi.DTOs.FeedbackResponses;

namespace HotelReservationApi.DTOs.Feedbacks
{
    public class FeedbackCreateDTO
    {
        public int FeedbackId { get; set; }
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
