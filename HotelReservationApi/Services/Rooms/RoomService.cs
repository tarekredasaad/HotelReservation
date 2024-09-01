using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomDTO> GetRooms()
        {
            var rooms = _roomRepository.GetAll();

            var roomDTOs = rooms.Map<RoomDTO>();

            return roomDTOs.ToList();
        }

        public RoomDTO GetRoomById(int id)
        {
            var room = _roomRepository.GetWithTrackinByID(id);

            var roomDTO = room.MapOne<RoomDTO>();

            return roomDTO;
        }

        public async Task<Room> AddRoom(RoomCreateDTO roomCreateDTO)
        {
            Room room = roomCreateDTO.MapOne<Room>();

            room = await _roomRepository.Add(room);

            var roomDTO = room.MapOne<RoomDTO>();

            return room;
        }

        public void DeleteRoom(int roomId)
        {
            _roomRepository.Delete(roomId);
        }

        public void UpdateRoom(RoomDTO roomDTO)
        {
            var room = roomDTO.MapOne<Room>();

            _roomRepository.Update(room);
        }

        public async Task SaveChangesAsync()
        {
            await _roomRepository.SaveChangesAsync();
        }

        public async Task<List<Room>> GetRoomsTypes(SearchReservationDTO searchReservation)
        {
           
            List<Room> rooms = _roomRepository.Get(r => r.Type == searchReservation.Types).ToList();
            
            return rooms;
        }
    }
}
