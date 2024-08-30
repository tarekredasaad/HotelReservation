using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Mediator.Reservations
{
    public interface IReservationMediator
    {
        Task<ReservationDTO> AddReservation(ReservationDTO reservationDTO);
        Task<string> CreateCheckOut(ConfirmReservationDTO confirmReservationDTO);
        Task<ReservationDTO> ConfirmReservation(ConfirmReservationDTO confirmReservationDTO);
        //bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<Room>> GetAvailableRooms(SearchReservationDTO searchReservationDTO);
    }
}