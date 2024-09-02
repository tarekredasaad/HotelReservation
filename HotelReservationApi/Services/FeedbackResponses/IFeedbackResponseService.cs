using HotelReservationApi.DTOs.FeedbackResponses;

namespace HotelReservationApi.Services.FeedbackResponses
{
    public interface IFeedbackResponseService
    {
        Task<FeedbackResponseDTO> AddFeedbackResponseAsync(FeedbackResponseDTO feedbackResponseDTO);
    }
}
