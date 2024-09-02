using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<Feedback> _feedbackRepository;

        public FeedbackService(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<FeedbackDTO> AddFeedbackAsync(FeedbackCreateDTO feedbackCreateDTO)
        {
            var feedback = feedbackCreateDTO.MapOne<Feedback>();
            
            feedback = await _feedbackRepository.AddAsync(feedback);
            
            var feedbackDTO = feedback.MapOne<FeedbackDTO>();

            return feedbackDTO;
        }

        public async Task<FeedbackDTO> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedback =  _feedbackRepository.GetByID(feedbackId);

            var feedbackDTO = feedback.MapOne<FeedbackDTO>();

            return feedbackDTO;
        }

        public async Task<FeedbackDTO> GetFeedbackByReservationIdAsync(int reservationId)
        {
            var feedback = await _feedbackRepository.First(f => f.ReservationId == reservationId);

            var feedbackDTO = feedback.MapOne<FeedbackDTO>();

            return feedbackDTO;
        }
    }
}
