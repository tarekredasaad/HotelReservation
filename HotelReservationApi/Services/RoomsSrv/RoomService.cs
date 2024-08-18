using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.FacilitiesSrv;

namespace HotelReservationApi.Services.RoomsSrv
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _repository;
        //IFacilitiesService facilitiesService;
        public RoomService(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public Room AddRoom(RoomCreateDTO roomCreateDTO)
        {
            Room room = new Room();

            room = roomCreateDTO.MapOne<Room>();


            return room;
            
        }
        public async Task SaveChange() 
        {
           await _repository.SaveChange();
        }
        public RoomDTO GetRoomById(int id)
        {
            var room = _repository.GetWithTrackinByID(id);

            return room.MapOne<RoomDTO>();
        }

        public IEnumerable<RoomDTO> GetRooms()
        {
            var rooms = _repository.GetAll();

            return rooms.Map<RoomDTO>();
        }

        //public int AddRoom(RoomCreateDTO roomCreateDTO)
        //{
        //    var room = roomCreateDTO.MapOne<Room>();

        //    _repository.Add(room);

        //    return room.Id;
        //}

        public void deleteRoom(int roomId)
        {
            _repository.Delete(roomId);
        }


        public void updateRoom(RoomDTO roomDTO)
        {
            var room = roomDTO.MapOne<Room>();

            _repository.Update(room);
        }
    }
}
