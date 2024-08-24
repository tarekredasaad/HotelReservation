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

        public async  Task<double> costRoom(int roomId , List<int> facilitiesIds)
        {
            double facilityCost=0;
            double roomCost=0;
            foreach (var id in facilitiesIds)
            {

                var roomFacility = await _RoomFacilitRepo.
                    GetAll(r => r.RoomId == roomId && r.FacilityId == id );
                 facilityCost += roomFacility.Sum(f => f.Facilities.Cost);
                 roomCost = roomFacility.FirstOrDefault().Room.Price;
            }
            return facilityCost + roomCost;

           
        }
    }
}
