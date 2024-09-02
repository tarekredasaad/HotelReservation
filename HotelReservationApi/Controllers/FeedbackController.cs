using HotelReservationApi.Helper;
using HotelReservationApi.Mediators.Feedbacks;
using HotelReservationApi.ViewModels;
using HotelReservationApi.ViewModels.FeedbackResponses;
using HotelReservationApi.ViewModels.Feedbacks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackMediator _feedbackMediator;

        public FeedbackController(IFeedbackMediator feedbackMediator)
        {
            _feedbackMediator = feedbackMediator;
        }

        [HttpPost]
        public async Task<ResultViewModel> SubmitFeedback(FeedbackViewModel feedbackCreateViewModel)
        {
            var feedbackDTO = await _feedbackMediator.AddFeedbackAsync(feedbackCreateViewModel);

            var feedbackViewModel = feedbackDTO.MapOne<FeedbackViewModel>();

            return ResultViewModel.Sucess(feedbackViewModel, "Feedback submitted Successfully.");
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel> GetFeedbackById(int id)
        {
            var feedbackDTO = await _feedbackMediator.GetFeedbackByIdAsync(id);

            var feedbackViewModel = feedbackDTO.MapOne<FeedbackViewModel>();

            return ResultViewModel.Sucess(feedbackViewModel);
        }

        [HttpPost]
        public async Task<ResultViewModel> RespondToFeedback(FeedbackResponseViewModel responseViewModel)
        {
            var feedbackResponseDTO = await _feedbackMediator.AddFeedbackResponseAsync(responseViewModel);
            
            var feedbackResponseViewModel = feedbackResponseDTO.MapOne<FeedbackResponseViewModel>();

            return ResultViewModel.Sucess(feedbackResponseViewModel, "Response submitted successfully.");
        }
    }
}
