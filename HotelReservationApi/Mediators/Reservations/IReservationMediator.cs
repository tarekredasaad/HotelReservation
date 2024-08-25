using HotelReservationApi.DTOs.Reservations;

namespace HotelReservationApi.Mediators.Reservations
{
    public interface IReservationMediator
    {
        Task<ReservationDTO> AddReservation(ReservationCreateDTO reservationCreateDTO);
    }
}
