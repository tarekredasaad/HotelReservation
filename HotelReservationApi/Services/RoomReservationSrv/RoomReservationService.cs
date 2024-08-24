using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.RoomFacilitySrv;

namespace HotelReservationApi.Services.RoomReservationSrv
{
    public class RoomReservationService : IRoomReservationService
    {
        IRepository<RoomReservation> _roomReservationRepository;
        IRoomFacilityService _roomFacilityService;
        
        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository
            , IRoomFacilityService roomReposatory
           )
        {
            _roomReservationRepository = roomReservationRepository;
            _roomFacilityService = roomReposatory;
        }

        public async Task<List<RoomReservation>> AddRoomReservation(RoomReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return null;
            }

            List<RoomReservation> roomReservations = new List<RoomReservation>();
           
            foreach (var id in reservationDTO.Rooms)
            {
                RoomReservation roomReservation = new RoomReservation();
                roomReservation.RoomId = id;
                roomReservation.ReservationId = reservationDTO.ReservationId;
                //roomReservation.IsReserved = true;
                //roomReservation.TotalPrice = await _roomFacilityService.costRoom(id);
               
                roomReservations.Add(roomReservation);
            }

            await _roomReservationRepository.AddRange(roomReservations);
            return roomReservations;
        }
    }
}

                     
               
                
