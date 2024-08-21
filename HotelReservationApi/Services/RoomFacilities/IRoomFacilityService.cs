using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomFacilities
{
    public interface IRoomFacilityService
    {
        Task AddRoomFacility(RoomFacilityDTO roomFacilityDTO);
        Task AddRange(int roomId, HashSet<int> facilityIDs);
        Task SaveChangesAsync();
    }
}
