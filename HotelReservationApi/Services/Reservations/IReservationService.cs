using HotelReservationApi.DTOs.Reservations;

namespace HotelReservationApi.Services.ReservationSrv
{
    public interface IReservationService
    {
        Task<ReservationDTO> AddReservation(ReservationDTO ReservationDTO);
        Task<ReservationDTO> UpdateReservation(ReservationDTO reservationDTO);
        bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate);
    }
}
