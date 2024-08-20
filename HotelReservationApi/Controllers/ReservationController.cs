using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> AddReservations(ReservationDTO reservationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState });
            };
            return Ok(_reservationMediator.AddReservation(reservationDTO));
        }

    }
}
