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

        public async Task AddRoomFacilities(RoomFacilityDTO roomFacilityDTO)
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

        public async  Task<double> costRoom(int roomId)
        {
            var roomFacility = await _RoomFacilitRepo.
                GetAll(r => r.RoomId == roomId, r => r.Facilities, r => r.Room);
            var facilityCost = roomFacility.Sum(f => f.Facilities.Cost);
            var roomCost = roomFacility.FirstOrDefault().Room.Price;
            return facilityCost + roomCost;

           
        }
    }
}
