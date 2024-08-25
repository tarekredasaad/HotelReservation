using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
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

        public async Task<ReservationDTO> AddReservation(ReservationDTO reservationCreateDTO)
        {

            Reservation reservation = reservationCreateDTO.MapOne<Reservation>();

            reservation = await _reservationRepository.AddAsync(reservation);

            await _reservationRepository.SaveChangesAsync();

            var reservationDTO = reservation.MapOne<ReservationDTO>();

            return reservationDTO;
        }

        public async Task<ReservationDTO> UpdateReservation(ReservationDTO reservationDTO)
        {
            var reservation = reservationDTO.MapOne<Reservation>();

            reservation = _reservationRepository.Update(reservation);

            await _reservationRepository.SaveChangesAsync();

            var updatedReservationDTO = reservation.MapOne<ReservationDTO>();

            return updatedReservationDTO;
        }

        public bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var reservation = _reservationRepository.First(r => r.RoomReservations.Any(rr => rr.RoomId == roomId) 
                && r.CheckInDate < checkInDate && r.CheckOutDate > checkOutDate);

            if (reservation is null)
            {
                return false;
            }

            return true;
        }
    }
}
