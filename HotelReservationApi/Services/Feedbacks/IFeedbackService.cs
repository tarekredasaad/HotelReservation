using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.DTOs.Feedbacks;

namespace HotelReservationApi.Services.Feedbacks
{
    public interface IFeedbackService
    {
        Task<FeedbackDTO> AddFeedbackAsync(FeedbackCreateDTO feedbackCreateDTO);
        Task<FeedbackDTO> GetFeedbackByIdAsync(int feedbackId);
    }
}
