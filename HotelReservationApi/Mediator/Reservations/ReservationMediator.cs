using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.Services.RoomFacilitySrv;
using HotelReservationApi.Services.RoomReservationSrv;
using HotelReservationApi.ViewModel;
using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Mediator.Reservations
{
    public class ReservationMediator : IReservationMediator
    {
        IReservationService _reservationService;
        IRoomReservationService _roomReservationService;
        IRoomFacilityService _roomFacilityService;

        public ReservationMediator(IReservationService reservationService
            , IRoomReservationService roomReservationService
            ,IRoomFacilityService roomFacilityService)
        {
            _reservationService = reservationService;
            _roomReservationService = roomReservationService;
            _roomFacilityService = roomFacilityService;
        }

        public async Task<ResultViewModel> AddReservation(ReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return ResultViewModel.Faliure();
            }

            //Reservation reservation = await _reservationService.AddReservation(reservationDTO);
            Reservation reservation = new Reservation();
            reservation = await _reservationService.AddReservation(reservationDTO);
            reservation.TotalPrice = await _roomFacilityService.costRoom(reservationDTO.roomFacilityDTOs);
            await _reservationService.SaveChange(reservation);
            RoomReservation roomReservation = new RoomReservation();
            roomReservation.ReservationId = reservation.Id;

            RoomReservationDTO roomReservationDTO = new RoomReservationDTO();
            //roomReservationDTO = reservation.MapOne<RoomReservationDTO>();
            roomReservationDTO = reservationDTO.MapOne<RoomReservationDTO>();
            roomReservationDTO.Reservation = reservation;
            roomReservationDTO.RoomFacilityDTO = reservationDTO.roomFacilityDTOs;
            List<RoomReservation> roomReservations = await _roomReservationService
                .AddRoomReservation(roomReservationDTO);

            return ResultViewModel.Sucess(roomReservations);

        }
    }
}
