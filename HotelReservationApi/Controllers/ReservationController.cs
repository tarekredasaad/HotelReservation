using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationMediator _reservationMediator;

        public ReservationController(IReservationMediator reservationMediator)
        {
            _reservationMediator = reservationMediator;
        }

        [HttpPost("AddReservations")]
        public async Task<ActionResult<ResultViewModel>> AddReservations(ReservationDTO reservationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState });
            };
            return Ok( await _reservationMediator.AddReservation(reservationDTO));
        }

        [HttpPost("charge")]
        public async  Task<ActionResult> CreateCheckOut(ConfirmReservationDTO confirmReservationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState });
            };

            return Ok(await _reservationMediator.CreateCheckOut(confirmReservationDTO));
        }


        [HttpPost("ConfirmReservation")]
        public async Task<ActionResult<ResultViewModel>> ConfirmReservation( ConfirmReservationDTO confirmReservationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState });
            };
            return Ok(await _reservationMediator.ConfirmReservation(confirmReservationDTO));
        }
        [HttpGet("getReservation")]
        public async Task<ActionResult<ResultViewModel>> getReservation([FromQuery] ConfirmReservationDTO confirmReservationDTO)
        {
            return Ok("success");
        }
    }
}
