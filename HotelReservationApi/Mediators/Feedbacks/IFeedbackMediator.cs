using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.DTOs.Feedbacks;

namespace HotelReservationApi.Mediators.Feedbacks
{
    public interface IFeedbackMediator
    {
        Task<ResultDTO> AddFeedbackAsync(FeedbackCreateDTO feedbackCreateDTO);
        Task<ResultDTO> GetFeedbackByIdAsync(int feedbackId);
        Task<ResultDTO> AddFeedbackResponseAsync(FeedbackResponseDTO responseDTO);
    }
}
