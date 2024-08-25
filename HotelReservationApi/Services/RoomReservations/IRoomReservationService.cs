using HotelReservationApi.DTOs.RoomReservations;

namespace HotelReservationApi.Services.RoomReservations
{
    public interface IRoomReservationService
    {
        Task AddRoomReservation(RoomReservationDTO roomReservationDTO);
        Task AddRange(List<RoomReservationDTO> roomReservationDTOs);
    }
}
