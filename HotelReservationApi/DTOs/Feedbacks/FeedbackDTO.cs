using HotelReservationApi.DTOs.FeedbackResponses;

namespace HotelReservationApi.DTOs.Feedbacks
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<FeedbackResponseDTO> Responses { get; set; }
    }
}
