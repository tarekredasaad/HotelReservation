using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.ReservationSrv
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(ReservationDTO ReservationDTO);
        Task SaveChangesAsync();
        Task<Reservation> Get(int id);
        Task<Reservation> Update(Reservation reservation);
        bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate);
    }
}
