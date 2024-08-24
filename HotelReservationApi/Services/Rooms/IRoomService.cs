using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.Rooms
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        Room AddRoom(RoomCreateDTO roomCreateDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void DeleteRoom(int roomId);
        Task SaveChangesAsync();
    }
}
