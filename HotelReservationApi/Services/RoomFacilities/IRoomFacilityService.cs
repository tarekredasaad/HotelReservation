using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomFacilities
{
    public interface IRoomFacilityService
    {
        Task GetRoomFacilities(RoomFacilityDTO roomFacilityDTO);
    }
}
