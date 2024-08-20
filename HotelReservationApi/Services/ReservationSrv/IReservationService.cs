using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.ReservationSrv
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(ReservationDTO ReservationDTO);
    }
}
