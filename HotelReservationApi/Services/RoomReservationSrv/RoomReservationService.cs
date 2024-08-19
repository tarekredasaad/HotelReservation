using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomReservationSrv
{
    public class RoomReservationService
    {
        IRepository<RoomReservation> _roomReservationRepository;

        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }

        public async Task<List<RoomReservation>> AddRoomReservation(RoomReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return null;
            }

            List<RoomReservation> roomReservations = new List<RoomReservation>();
            foreach(var id in reservationDTO.RoomIds)
            {
                RoomReservation roomReservation = new RoomReservation();
                roomReservation.RoomId = id;
                roomReservation.ReservationId = reservationDTO.ReservationId;
                roomReservation.Status = ReservationStatus.Reserved;
                roomReservation.IsReserved = true;
                //var cost = _roomReservationRepository.Include(RoomFacility);
                roomReservations.Add(roomReservation);
            }

           await _roomReservationRepository.AddRange(roomReservations);
            return roomReservations;
        }
    }
}
