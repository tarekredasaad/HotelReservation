using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;
using System;

namespace HotelReservationApi.Services.ReservationSrv
{
    public class ReservationService : IReservationService
    {
        IRepository<Reservation> _repository;

        public ReservationService(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<Reservation> AddReservation(ReservationDTO reservationDTO)
        {
            Reservation reservation = reservationDTO.MapOne<Reservation>();
            reservation.IsConfirmed = false;
            reservation.Status = ReservationStatus.Pending;

            reservation.NumberDays = (reservationDTO.From - reservationDTO.To).Days;

            await _repository.Add(reservation);

            return reservation;
        }
        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public async Task<Reservation> Get(int id)
        {
            Reservation reservation = _repository.GetByID(id);
            return reservation;
        }

        public async Task<Reservation> Update(Reservation reservation)
        {
            Reservation reservation_x = await _repository.Update(reservation);
            return reservation_x;
        }

        public bool IsRoomAvailable(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var reservation = _repository.First(r => r.RoomReservations.Any(rr => rr.RoomId == roomId)
                && r.To < checkInDate && r.From > checkOutDate);

            if (reservation is null)
            {
                return false;
            }

            return true;
        }

       
    }
}
