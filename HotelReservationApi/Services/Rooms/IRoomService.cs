using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomsSrv
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        Task<Room> AddRoom(RoomCreateDTO roomCreateDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void DeleteRoom(int roomId);
        Task SaveChangesAsync();
    }
}
