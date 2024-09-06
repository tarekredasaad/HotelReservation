using FluentValidation;
using FluentValidation.Results;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.Services;
using HotelReservationApi.ViewModels;
using HotelReservationApi.ViewModels.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationMediator _reservationMediator;
        private readonly IValidator<ReservationViewModel> _reservationValidator;
        private readonly IValidator<ReservationConfirmDTO> _confirmReservationValidator;

        public ReservationController(IReservationMediator reservationMediator, 
            IValidator<ReservationViewModel> reservationValidator, 
            IValidator<ReservationConfirmDTO> confirmReservationValidator)
        {
            _reservationMediator = reservationMediator;
            _reservationValidator = reservationValidator;
            _confirmReservationValidator = confirmReservationValidator;
        }
        //[Authorize(Policy = "Customer")]
        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> AddReservation(ReservationDTO reservationCreateVM)
        {
           

            var reservationDTO = await _reservationMediator.AddReservation(reservationCreateVM);

            return Ok(ResultViewModel.Sucess(reservationDTO, "Reservation created successfully."));
        }
       // [Authorize(Policy = "Customer")]
        [HttpPost]
        public async  Task<ActionResult<ResultViewModel>> CreateCheckOutURL(ReservationConfirmDTO confirmReservationDTO)
        {
            
            ValidationResult result = _confirmReservationValidator.Validate(confirmReservationDTO);

            if (!result.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(result.Errors.First().ToString()));
            };

            string checkOutURL = await _reservationMediator.CreateCheckOut(confirmReservationDTO);

            return Ok(ResultViewModel.Sucess(checkOutURL, "Checkout URL created successfully."));
        }


        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> ConfirmReservation(ReservationConfirmDTO confirmReservationDTO)
        {
            if (TokenGenerator.token is null)
            {
                return BadRequest(ResultViewModel
                    .Faliure("The User is not authenticated you shoud make login First"));
            }
            ValidationResult result = _confirmReservationValidator.Validate(confirmReservationDTO);

            if (!result.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(result.Errors.First().ToString()));
            };

            var reservationDTO = await _reservationMediator.ConfirmReservation(confirmReservationDTO);

            return Ok(ResultViewModel.Sucess(reservationDTO, "The reservation confirmed successfully."));
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> GetRoomAvailable(SearchReservationDTO searchReservationDTO)
        {
            var rooms =await _reservationMediator.GetAvailableRooms(searchReservationDTO);

            return Ok(ResultViewModel.Sucess(rooms));
            
        }
    }
}
