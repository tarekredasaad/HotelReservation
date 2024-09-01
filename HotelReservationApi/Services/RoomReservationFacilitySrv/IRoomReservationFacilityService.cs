using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomReservationFacilitySrv
{
    public interface IRoomReservationFacilityService
    {
        Task<List<RoomReservationFacilities>>
            Add(List<RoomReservation> roomReservations
            , HashSet<RoomFacilityDTO> roomFacilityDTOs);
    }
}
