using HotelReservationApi.DTOs;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomFacilitySrv
{
    public interface IRoomFacilityService
    {

        Task GetRoomFacilities(RoomFacilityDTO roomFacilityDTO);
    }
}
