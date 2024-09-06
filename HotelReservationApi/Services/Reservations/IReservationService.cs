using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels;

namespace HotelReservationApi.Services.Reservations
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(ReservationDTO ReservationDTO);
        Task SaveChangesAsync();
        Task<Reservation> Get(int id);
        Task<Reservation> Update(ReservationDTO reservationDTO, int id);
        Task<Reservation> UpdateToConfirm(Reservation reservation);
       Task<List<Reservation>> GetAll();
        Task<List<Reservation>> GetReservationAvailable(SearchReservationDTO searchReservationDTO);
    }
}
