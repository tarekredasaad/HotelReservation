using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomReservationFacilities
{
    public interface IRoomReservationFacilityService
    {
        Task<List<RoomReservationFacility>>
            Add(List<RoomReservation> roomReservations
            , HashSet<RoomFacilityDTO> roomFacilityDTOs);
    }
}
