using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Services.Rooms
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        Task<RoomDTO> AddRoom(RoomCreateDTO roomCreateDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void DeleteRoom(int roomId);
        Task SaveChangesAsync();
    }
}
