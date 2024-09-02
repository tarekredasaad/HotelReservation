using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.ViewModels.FeedbackResponses;
using HotelReservationApi.ViewModels.Feedbacks;

namespace HotelReservationApi.Mediators.Feedbacks
{
    public interface IFeedbackMediator
    {
        Task<FeedbackDTO> AddFeedbackAsync(FeedbackViewModel feedbackViewModel);
        Task<FeedbackDTO> GetFeedbackByIdAsync(int feedbackId);
        Task<FeedbackResponseDTO> AddFeedbackResponseAsync(FeedbackResponseViewModel responseViewModel);
    }
}
