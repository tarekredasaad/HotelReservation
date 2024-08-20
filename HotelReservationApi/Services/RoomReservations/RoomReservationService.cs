using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomReservations
{
    public class RoomReservationService : IRoomReservationService
    {
        IRepository<RoomReservation> _roomReservationRepository;

        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }

        public async Task<RoomReservationDTO> AddRoomReservation(RoomReservationDTO roomReservationDTO)
        {
            RoomReservation roomReservation = roomReservationDTO.MapOne<RoomReservation>();

            roomReservation = await _roomReservationRepository.Add(roomReservation);

            var result = roomReservation.MapOne<RoomReservationDTO>();

            return result;
        }
    }
}
