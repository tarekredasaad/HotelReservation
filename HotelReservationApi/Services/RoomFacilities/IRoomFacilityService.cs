using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomFacilities
{
    public interface IRoomFacilityService
    {
        Task AddRoomFacility(RoomFacilityDTO roomFacilityDTO);
        void AddRange(RoomDTO room, HashSet<int> facilityIDs);
        Task<double> CostRoom(HashSet<RoomFacilityDTO> reservationFacilityDTOs);
        Task SaveChangesAsync();
    }
}
