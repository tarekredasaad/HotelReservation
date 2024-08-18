using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Services.RoomsSrv
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        int AddRoom(RoomCreateDTO roomCreateDTO);
        void updateRoom(RoomDTO roomDTO);
        void deleteRoom(int roomId);
    }
}
