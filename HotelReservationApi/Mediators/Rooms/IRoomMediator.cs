using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Mediators.Rooms
{
    public interface IRoomMediator
    {
        List<RoomDTO> GetRooms();
        Task<RoomDTO> AddRoom(RoomCreateDTO roomCreateDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void RemoveRoom(int id);
    }
}
