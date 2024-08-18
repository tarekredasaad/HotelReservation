using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomFacilitySrv
{
    public class RoomFacilityService : IRoomFacilityService
    {
        IRepository<RoomFacility> _RoomFacilitRepo;

        public RoomFacilityService(IRepository<RoomFacility> RoomsFacilitRepo) 
        {
            _RoomFacilitRepo = RoomsFacilitRepo;
        }

        public async Task GetRoomFacilities(RoomFacilityDTO roomFacilityDTO)
        {
            if(roomFacilityDTO == null)
            {
                return ;
            }
            List<RoomFacility> roomFacilitiesList = new List<RoomFacility>();

            foreach (var id in roomFacilityDTO.FacilityIds)
            {
                RoomFacility roomFacilities = new RoomFacility();
                roomFacilities.FacilityId = id;
                roomFacilities.RoomId = roomFacilityDTO.RoomId;
                roomFacilitiesList.Add(roomFacilities);
            }
            await _RoomFacilitRepo.AddRange(roomFacilitiesList);

            
        }
    }
}
