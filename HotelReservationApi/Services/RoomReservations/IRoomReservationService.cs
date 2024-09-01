using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomReservations
{
    public interface IRoomReservationService
    {
        Task<List<RoomReservation>> AddRoomReservation(RoomReservationDTO reservationDTO);
        Task<List<RoomReservation>> getRooms();
    }
}
