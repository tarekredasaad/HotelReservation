using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Mediators.Rooms
{
    public interface IRoomMediator
    {
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        Task<RoomDTO> AddRoomAsync(RoomCreateDTO roomCreateDTO);
        Task UpdateRoomAsync(RoomDTO roomDTO);
        Task DeleteRoomAsync(int id);
    }
}
