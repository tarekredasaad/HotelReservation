using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.Helper;
using HotelReservationApi.Services.FeedbackResponses;
using HotelReservationApi.Services.Feedbacks;
using HotelReservationApi.ViewModels.FeedbackResponses;
using HotelReservationApi.ViewModels.Feedbacks;

namespace HotelReservationApi.Mediators.Feedbacks
{
    public class FeedbackMediator : IFeedbackMediator
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IFeedbackResponseService _feedbackResponseService;

        public FeedbackMediator(IFeedbackService feedbackService, 
            IFeedbackResponseService feedbackResponseService)
        {
            _feedbackService = feedbackService;
            _feedbackResponseService = feedbackResponseService;
        }

        public async Task<FeedbackDTO> AddFeedbackAsync(FeedbackViewModel feedbackViewModel)
        {
            var feedbackCreateDTO = feedbackViewModel.MapOne<FeedbackCreateDTO>();

            var feedbackDTO = await _feedbackService.AddFeedbackAsync(feedbackCreateDTO);
        
            return feedbackDTO;
        }

        public async Task<FeedbackDTO> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedbackDTO = await _feedbackService.GetFeedbackByIdAsync(feedbackId);

            return feedbackDTO;
        }

        public async Task<FeedbackResponseDTO> AddFeedbackResponseAsync(FeedbackResponseViewModel responseViewModel)
        {
            var feedbackResponseDTO = responseViewModel.MapOne<FeedbackResponseDTO>();

            feedbackResponseDTO = await _feedbackResponseService.AddFeedbackResponseAsync(feedbackResponseDTO);
            
            return feedbackResponseDTO;
        }
    }
}
