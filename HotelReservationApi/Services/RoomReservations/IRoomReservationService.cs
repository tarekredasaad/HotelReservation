using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Services.RoomReservations
{
    public interface IRoomReservationService
    {
        Task AddRoomReservation(RoomReservationDTO roomReservationDTO);
        Task AddRange(List<RoomReservationDTO> roomReservationDTOs);
    }
}
