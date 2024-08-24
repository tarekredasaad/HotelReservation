using HotelReservationApi.DTOs.Reservations;

namespace HotelReservationApi.Services.ReservationSrv
{
    public interface IReservationService
    {
        Task<ReservationDTO> AddReservation(CreateReservationDTO ReservationDTO);
    }
}
