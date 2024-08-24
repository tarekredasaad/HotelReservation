using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.RoomFacilities
{
    public class RoomFacilityService : IRoomFacilityService
    {
        IRepository<RoomFacility> _roomFacilityRepository;

        public RoomFacilityService(IRepository<RoomFacility> roomFacilityRepository)
        {
            _roomFacilityRepository = roomFacilityRepository;
        }

        public void AddRoomFacility(RoomFacilityDTO roomFacilityDTO)
        {
            RoomFacility roomFacility = roomFacilityDTO.MapOne<RoomFacility>();

            roomFacility = _roomFacilityRepository.Add(roomFacility);
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

        public async Task SaveChangesAsync()
        {
            await _roomFacilityRepository.SaveChangesAsync();
        }
    }
}
