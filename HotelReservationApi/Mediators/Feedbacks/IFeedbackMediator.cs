using HotelReservationApi.ViewModels.FeedbackResponses;
using HotelReservationApi.ViewModels.Feedbacks;

namespace HotelReservationApi.Mediators.Feedbacks
{
    public interface IFeedbackMediator
    {
        Task<FeedbackViewModel> AddFeedbackAsync(FeedbackViewModel feedbackViewModel);
        Task<FeedbackViewModel> GetFeedbackByIdAsync(int feedbackId);
    }
}
