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
            

            reservation.NumberDays = (reservationDTO.To - reservationDTO.From).Days;

            await _repository.Add(reservation);

            return reservation;
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
        public async Task<List<Reservation>> GetAll()
        {
            List<Reservation> reservations = _repository.GetAll().ToList();
            return reservations;
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

        public async Task<List<Reservation>> GetReservationAvailable( SearchReservationDTO searchReservationDTO)
        {
            var reservation =await _repository.GetAll(r => 
                 r.To < searchReservationDTO.To && r.From > searchReservationDTO.From);
                       
            return reservation;
        }
               
    }
}
