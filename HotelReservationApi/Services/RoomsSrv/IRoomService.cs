using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomsSrv
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        Room AddRoom(RoomCreateDTO roomCreateDTO);
        void updateRoom(RoomDTO roomDTO);
        Task SaveChange();
        void deleteRoom(int roomId);
    }
}
