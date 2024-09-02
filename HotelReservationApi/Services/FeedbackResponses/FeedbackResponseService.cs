using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.FeedbackResponses
{
    public class FeedbackResponseService : IFeedbackResponseService
    {
        private readonly IRepository<FeedbackResponse> _feedbackResponseRepository;

        public FeedbackResponseService(IRepository<FeedbackResponse> feedbackResponseRepository)
        {
            _feedbackResponseRepository = feedbackResponseRepository;
        }

        public async Task<FeedbackResponseDTO> AddFeedbackResponseAsync(FeedbackResponseDTO feedbackResponseDTO)
        {
            var feedbackResponse = feedbackResponseDTO.MapOne<FeedbackResponse>();


            feedbackResponse = await _feedbackResponseRepository.AddAsync(feedbackResponse);
            
            return feedbackResponse.MapOne<FeedbackResponseDTO>();
        }
    }
}
