using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.ReservationSrv
{
    public class ReservationService : IReservationService
    {
        IRepository<Reservation> _repository;

        public ReservationService(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<Reservation> AddReservation(ReservationDTO ReservationDTO)
        {
            

            Reservation reservation = new Reservation();
            reservation = ReservationDTO.MapOne<Reservation>();

            reservation = await _repository.Add(reservation);

            await _repository.SaveChange();

            return reservation;
        }
    }
}
