using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Mediator.Reservations
{
    public interface IReservationMediator
    {
        Task<ResultViewModel> AddReservation(ReservationDTO reservationDTO);
    }
}
