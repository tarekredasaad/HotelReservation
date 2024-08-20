using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomFacilities
{
    public class RoomFacilityService : IRoomFacilityService
    {
        IRepository<RoomFacility> _roomFacilityRepository;

        public RoomFacilityService(IRepository<RoomFacility> roomFacilityRepository)
        {
            _roomFacilityRepository = roomFacilityRepository;
        }

        public async Task GetRoomFacilities(RoomFacilityDTO roomFacilityDTO)
        {
            if (roomFacilityDTO == null)
            {
                return;
            }

            List<RoomFacility> roomFacilitiesList = new List<RoomFacility>();

            foreach (var id in roomFacilityDTO.FacilityIds)
            {
                RoomFacility roomFacilities = new RoomFacility();
                roomFacilities.FacilityId = id;
                roomFacilities.RoomId = roomFacilityDTO.RoomId;
                roomFacilitiesList.Add(roomFacilities);
            }

            await _roomFacilityRepository.AddRange(roomFacilitiesList);
        }
    }
}
