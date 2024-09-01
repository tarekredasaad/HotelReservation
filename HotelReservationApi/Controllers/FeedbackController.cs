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
            var feedbackViewModel = await _feedbackMediator.AddFeedbackAsync(feedbackCreateViewModel);
            
            return ResultViewModel.Sucess(feedbackViewModel, "Feedback submitted Successfully.");
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel> GetFeedbackById(int id)
        {
            var feedbackViewModel = await _feedbackMediator.GetFeedbackByIdAsync(id);
            
            return ResultViewModel.Sucess(feedbackViewModel);
        }
    }
}
