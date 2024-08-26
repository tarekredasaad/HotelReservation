using FluentValidation;
using FluentValidation.Results;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.ViewModel;
using HotelReservationApi.ViewModel.Reservations;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationMediator _reservationMediator;
        private readonly IValidator<ReservationViewModel> _reservationValidator;
        private readonly IValidator<ConfirmReservationDTO> _confirmReservationValidator;

        public ReservationController(IReservationMediator reservationMediator, 
            IValidator<ReservationViewModel> reservationValidator, 
            IValidator<ConfirmReservationDTO> confirmReservationValidator)
        {
            _reservationMediator = reservationMediator;
            _reservationValidator = reservationValidator;
            _confirmReservationValidator = confirmReservationValidator;
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> AddReservation(ReservationViewModel reservationCreateVM)
        {
            ValidationResult result = _reservationValidator.Validate(reservationCreateVM);

            if (!result.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(result.Errors.First().ToString()));
            }

            var reservationCreateDTO = reservationCreateVM.MapOne<ReservationDTO>();

            var reservationDTO = await _reservationMediator.AddReservation(reservationCreateDTO);

            return Ok(ResultViewModel.Sucess(reservationDTO, "Reservation created successfully."));
        }

        [HttpPost]
        public async  Task<ActionResult<ResultViewModel>> CreateCheckOutURL(ConfirmReservationDTO confirmReservationDTO)
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
        public async Task<ActionResult<ResultViewModel>> ConfirmReservation(ConfirmReservationDTO confirmReservationDTO)
        {
            ValidationResult result = _confirmReservationValidator.Validate(confirmReservationDTO);

            if (!result.IsValid)
            {
                return BadRequest(ResultViewModel.Faliure(result.Errors.First().ToString()));
            };

            var reservationDTO = await _reservationMediator.ConfirmReservation(confirmReservationDTO);

            return Ok(ResultViewModel.Sucess(reservationDTO, "The reservation confirmed successfully."));
        }

        [HttpPost]
        public async Task<ResultViewModel> IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            bool isAvailable = _reservationMediator.IsRoomAvailable(roomId, checkInDate, checkOutDate);

            return ResultViewModel.Sucess(isAvailable);
            
        }
    }
}
