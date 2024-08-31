using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediators.Reservations;
using HotelReservationApi.ViewModel;
using HotelReservationApi.ViewModels.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationMediator _reservationMediator;

        public ReservationController(ReservationMediator reservationMediator)
        {
            _reservationMediator = reservationMediator;
        }

        [HttpPost]
        [Authorize(Policy = "Staff")]
        public async Task<ResultViewModel> AddReservation(ReservationCreateViewModel reservationCreateVM)
        {
            var reservationCreateDTO = reservationCreateVM.MapOne<ReservationCreateDTO>();
            var reservationDTO = await _reservationMediator.AddReservation(reservationCreateDTO);

            var reservationVM = reservationDTO.MapOne<ReservationViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 201,
                Data = reservationVM,
            };
        }

        [HttpPost]
        [Authorize(Policy = "Customer")]
        public async Task<ResultViewModel> IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            bool isAvailable = _reservationMediator.IsRoomAvailable(roomId, checkInDate, checkOutDate);

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = isAvailable,
            };
        }
    }
}
