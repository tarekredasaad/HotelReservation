using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        IRepository<Reservation> _reservationRepository;

        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationDTO> AddReservation(CreateReservationDTO ReservationDTO)
        {
            Reservation reservation = ReservationDTO.MapOne<Reservation>();

            reservation = await _reservationRepository.Add(reservation);

            await _reservationRepository.SaveChangesAsync();

            var reservationDTO = reservation.MapOne<ReservationDTO>();

            return reservationDTO;
        }
    }
}
