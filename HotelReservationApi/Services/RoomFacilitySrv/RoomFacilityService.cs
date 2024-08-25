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

        public async  Task<double> costRoom(HashSet<RoomFacilityDTO> roomFacilityDTOs)
        {
            double facilityCost=0;
            double roomCost=0;
            double cost = 0;
            foreach (var roomFacilityDTO in roomFacilityDTOs)
            {
                foreach (var id in roomFacilityDTO.FacilityIds)
                {

                    var roomFacility = await _RoomFacilitRepo.
                        GetAll(r => r.RoomId == roomFacilityDTO.RoomId && r.FacilityId == id,r=>r.Room ,r=>r.Facilities);
                    facilityCost += roomFacility.FirstOrDefault().Facilities.Cost;
                    roomCost = roomFacility.FirstOrDefault().Room.Price;
                }
                cost += roomCost + facilityCost;
            }
            return cost;

           
        }
    }
}
