using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.Helper;
using HotelReservationApi.Services.Feedbacks;
using HotelReservationApi.ViewModels.Feedbacks;

namespace HotelReservationApi.Mediators.Feedbacks
{
    public class FeedbackMediator : IFeedbackMediator
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackMediator(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public async Task<FeedbackViewModel> AddFeedbackAsync(FeedbackViewModel feedbackViewModel)
        {
            var feedbackCreateDTO = feedbackViewModel.MapOne<FeedbackCreateDTO>();

            var feedbackDTO = await _feedbackService.AddFeedbackAsync(feedbackCreateDTO);
        
            return feedbackDTO.MapOne<FeedbackViewModel>();
        }

        public async Task<FeedbackViewModel> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedbackDTO = await _feedbackService.GetFeedbackByIdAsync(feedbackId);
            
            var feedbackViewModel = feedbackDTO.MapOne<FeedbackViewModel>();

            return feedbackViewModel;
        }
    }
}
