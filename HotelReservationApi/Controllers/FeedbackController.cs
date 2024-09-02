using FluentValidation;
using FluentValidation.Results;
using HotelReservationApi.DTOs.FeedbackResponses;
using HotelReservationApi.DTOs.Feedbacks;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediators.Feedbacks;
using HotelReservationApi.ViewModels;
using HotelReservationApi.ViewModels.FeedbackResponses;
using HotelReservationApi.ViewModels.Feedbacks;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackMediator _feedbackMediator;
        private readonly IValidator<FeedbackViewModel> _feedbackValidator;
        private readonly IValidator<FeedbackResponseViewModel> _feedbackResponseValidator;

        public FeedbackController(IFeedbackMediator feedbackMediator, 
            IValidator<FeedbackViewModel> feedbackValidator, 
            IValidator<FeedbackResponseViewModel> feedbackResponseValidator)
        {
            _feedbackMediator = feedbackMediator;
            _feedbackValidator = feedbackValidator;
            _feedbackResponseValidator = feedbackResponseValidator;
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> SubmitFeedback(FeedbackViewModel feedbackCreateViewModel)
        {
            ValidationResult valdiationResult = _feedbackValidator.Validate(feedbackCreateViewModel);

            if (!valdiationResult.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(valdiationResult.Errors.First().ToString()));
            }

            var feedbackCreateDTO = feedbackCreateViewModel.MapOne<FeedbackCreateDTO>();

            var mediatorResult = await _feedbackMediator.AddFeedbackAsync(feedbackCreateDTO);

            if (!mediatorResult.IsSuccess)
            {
                return BadRequest(ResultViewModel.Faliure(mediatorResult.Message));
            }

            var feedbackViewModel = mediatorResult.Data.MapOne<FeedbackViewModel>();

            return Ok(ResultViewModel.Sucess(feedbackViewModel, "Feedback submitted Successfully."));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultViewModel>> GetFeedbackById(int id)
        {
            if (id == 0)
            {
                return BadRequest(ResultViewModel.Faliure("Feedback Id must be greater than zero!"));
            }

            var feedbackDTO = await _feedbackMediator.GetFeedbackByIdAsync(id);

            var feedbackViewModel = feedbackDTO.MapOne<FeedbackViewModel>();

            return Ok(ResultViewModel.Sucess(feedbackViewModel));
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> RespondToFeedback(FeedbackResponseViewModel responseViewModel)
        {
            ValidationResult valdiationResult = _feedbackResponseValidator.Validate(responseViewModel);

            if (!valdiationResult.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(valdiationResult.Errors.First().ToString()));
            }

            var feedbackResponseDTO = responseViewModel.MapOne<FeedbackResponseDTO>();

            var mediatorResult = await _feedbackMediator.AddFeedbackResponseAsync(feedbackResponseDTO);

            if (!mediatorResult.IsSuccess)
            {
                return BadRequest(ResultViewModel.Faliure(mediatorResult.Message));
            }

            var feedbackResponseViewModel = mediatorResult.Data.MapOne<FeedbackResponseViewModel>();

            return Ok(ResultViewModel.Sucess(feedbackResponseViewModel, "Response submitted successfully."));
        }
    }
}
