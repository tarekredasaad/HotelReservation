using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.Services.RoomReservationSrv;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Mediator.Reservations
{
    public class ReservationMediator : IReservationMediator
    {
        IReservationService _reservationService;
        IRoomReservationService _roomReservationService;

        public ReservationMediator(IReservationService reservationService, IRoomReservationService roomReservationService)
        {
            _reservationService = reservationService;
            _roomReservationService = roomReservationService;
        }

        public async Task<ResultViewModel> AddReservation(ReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return ResultViewModel.Faliure();
            }

            Reservation reservation = await _reservationService.AddReservation(reservationDTO);
            RoomReservationDTO roomReservationDTO = new RoomReservationDTO();
            //roomReservationDTO = reservation.MapOne<RoomReservationDTO>();
            roomReservationDTO = reservationDTO.MapOne<RoomReservationDTO>();
            roomReservationDTO.ReservationId = reservation.Id;
            List<RoomReservation> roomReservations = await _roomReservationService
                .AddRoomReservation(roomReservationDTO);

            return ResultViewModel.Sucess(roomReservations);

        }
    }
}
