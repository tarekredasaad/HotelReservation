using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomFacilities
{
    public interface IRoomFacilityService
    {
        void AddRoomFacility(RoomFacilityDTO roomFacilityDTO);
        void AddRange(RoomDTO room, HashSet<int> facilityIDs);
        Task SaveChangesAsync();
    }
}
