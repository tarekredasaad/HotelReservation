using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.ReservationSrv
{
    public interface IReservationService
    {
        Reservation AddReservation(ReservationDTO ReservationDTO);
        Task SaveChange(Reservation Reservation);
    }
}
