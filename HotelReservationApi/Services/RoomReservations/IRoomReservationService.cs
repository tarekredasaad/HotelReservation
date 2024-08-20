using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Services.RoomReservations
{
    public interface IRoomReservationService
    {
        Task<RoomReservationDTO> AddRoomReservation(RoomReservationDTO roomReservationDTO);
    }
}
