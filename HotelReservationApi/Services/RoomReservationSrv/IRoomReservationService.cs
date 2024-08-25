using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomReservationSrv
{
    public interface IRoomReservationService
    {
        List<RoomReservation> AddRoomReservation(RoomReservationDTO reservationDTO);
    }
}
