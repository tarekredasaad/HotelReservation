using HotelReservationApi.Constant.Enum;
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

        public  Reservation AddReservation(ReservationDTO ReservationDTO)
        {
            

            Reservation reservation = new Reservation();
            reservation = ReservationDTO.MapOne<Reservation>();
            reservation.IsConfirmed = false;
            reservation.Status = ReservationStatus.pending;

            reservation.NumberDays = 5;

            return reservation;
        }
        public async Task SaveChange(Reservation Reservation)
        {
            Reservation reservation = new Reservation();
            reservation = await _repository.Add(Reservation);
            await _repository.SaveChange();
        }
    }
}
