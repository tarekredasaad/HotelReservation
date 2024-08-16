using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomsSrv
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _repository;

        public RoomService(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public int AddRoom(RoomCreateDTO roomCreateDTO)
        {
            throw new NotImplementedException();
        }

        public void deleteRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        public RoomDTO GetRoomById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomDTO> GetRooms()
        {
            throw new NotImplementedException();
        }

        public void updateRoom(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }
    }
}
