using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;

namespace HotelReservationApi.Mediator.Reservations
{
    public interface IReservationMediator
    {
        Task<ReservationDTO> AddReservation(ReservationDTO reservationDTO);
        Task<string> CreateCheckOut(ReservationConfirmDTO confirmReservationDTO);
        Task<ReservationDTO> ConfirmReservation(ReservationConfirmDTO confirmReservationDTO);
        //bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<Room>> GetAvailableRooms(SearchReservationDTO searchReservationDTO);
    }
}