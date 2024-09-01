using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomsSrv
{
    public interface IRoomService
    {
        List<RoomDTO> GetRooms();
        RoomDTO GetRoomById(int id);
        Task<Room> AddRoom(RoomCreateDTO roomCreateDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void DeleteRoom(int roomId);
        Task SaveChangesAsync();
        Task<List<Room>> GetRoomsTypes(SearchReservationDTO searchReservation);
    }
}
