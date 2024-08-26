using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
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

        public async Task AddRoomFacility(RoomFacilityDTO roomFacilityDTO)
        {
            RoomFacility roomFacility = roomFacilityDTO.MapOne<RoomFacility>();

            roomFacility = await _roomFacilityRepository.Add(roomFacility);
        }

        public void AddRange(RoomDTO roomDTO, HashSet<int> FacilityIDs)
        {
            foreach (var facilityId in FacilityIDs)
            {
                RoomFacility roomFacility = new RoomFacility()
                {
                    RoomId = roomDTO.Id,
                    FacilityId = facilityId
                };

                _roomFacilityRepository.Add(roomFacility);
            }
        }

        public async Task<double> CostRoom(HashSet<RoomFacilityDTO> roomFacilityDTOs)
        {
            double roomCost = 0;
            double cost = 0;

            foreach (var roomFacilityDTO in roomFacilityDTOs)
            {
                double facilityCost = 0;

                var roomFacility = await _roomFacilityRepository.
                    GetAll(r => r.RoomId == roomFacilityDTO.RoomId , r => r.Room, r => r.Facility);
                foreach (var id in roomFacilityDTO.FacilityId)
                {

                    facilityCost += roomFacility.FirstOrDefault().Facility.Cost;
                    roomCost = roomFacility.FirstOrDefault().Room.Price;
                    
                }

                    cost += roomCost + facilityCost;
            }

            return cost;
        }

        public async Task SaveChangesAsync()
        {
            await _roomFacilityRepository.SaveChangesAsync();
        }
    }
}
