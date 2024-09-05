using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.Services;
using HotelReservationApi.Services.FeedbackResponses;
using HotelReservationApi.Services.Feedbacks;
using HotelReservationApi.Services.Users;

namespace HotelReservationApi.Mediators.Feedbacks
{
    public class FeedbackMediator : IFeedbackMediator
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IFeedbackResponseService _feedbackResponseService;
        IUserService _userService;
        IHttpContextAccessor _httpContextAccessor;
        public FeedbackMediator(IFeedbackService feedbackService,
            IUserService userService,
            IHttpContextAccessor httpContextAccessor,
        IFeedbackResponseService feedbackResponseService)
        {
            _feedbackService = feedbackService;
            _feedbackResponseService = feedbackResponseService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResultDTO> AddFeedbackAsync(FeedbackCreateDTO feedbackCreateDTO)
        {
            var existingFeedback = await _feedbackService.GetFeedbackByReservationIdAsync(feedbackCreateDTO.ReservationId);
            
            if (existingFeedback != null)
            {
                return ResultDTO.Faliure("Feedback has already been submitted for this reservation.");
            }
            string token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");

            feedbackCreateDTO.CustomerId = await _userService.GetUserIdFromToken(token);
            var feedbackDTO = await _feedbackService.AddFeedbackAsync(feedbackCreateDTO);
        
            return ResultDTO.Sucess(feedbackDTO);
        }

        public async Task<ResultDTO> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedbackDTO = await _feedbackService.GetFeedbackByIdAsync(feedbackId);

            if (feedbackDTO is null) 
            {
                return ResultDTO.Faliure("Feedback doesn't exists!");
            }

            return ResultDTO.Sucess(feedbackDTO);
        }

        public async Task<ResultDTO> AddFeedbackResponseAsync(FeedbackResponseDTO responseDTO)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(responseDTO.FeedbackId);
            
            if (feedback is null)
            {
                return ResultDTO.Faliure("Feedback doesn't exists!");
            }

            var feedbackResponseDTO = await _feedbackResponseService.AddFeedbackResponseAsync(responseDTO);

            return ResultDTO.Sucess(feedbackResponseDTO);
        }
    }
}
