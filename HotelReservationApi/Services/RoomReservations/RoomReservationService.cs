using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.RoomReservations
{
    public class RoomReservationService : IRoomReservationService
    {
        IRepository<RoomReservation> _roomReservationRepository;

        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }

        public async Task AddRoomReservation(RoomReservationDTO roomReservationDTO)
        {
            RoomReservation roomReservation = roomReservationDTO.MapOne<RoomReservation>();

            roomReservation = await _roomReservationRepository.AddAsync(roomReservation);

            await _roomReservationRepository.SaveChangesAsync();
        }

        public async Task AddRange(List<RoomReservationDTO> roomReservationDTOs)
        {
            foreach(var roomReservationDTO in roomReservationDTOs)
            {
                var roomReservation = roomReservationDTO.MapOne<RoomReservation>();
                await _roomReservationRepository.AddAsync(roomReservation);
            }

            await _roomReservationRepository.SaveChangesAsync();
        }
    }
}
