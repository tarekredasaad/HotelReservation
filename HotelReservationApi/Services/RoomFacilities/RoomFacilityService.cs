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

        public async Task AddRoomFacility(RoomFacilityDTO roomFacilityDTO)
        {
            RoomFacility roomFacility = roomFacilityDTO.MapOne<RoomFacility>();

            roomFacility = await _roomFacilityRepository.Add(roomFacility);
        }

        public async Task AddRange(int roomId, HashSet<int> FacilityIDs)
        {
            foreach (var facilityId in FacilityIDs)
            {
                RoomFacility roomFacility = new RoomFacility()
                {
                    RoomId = roomId,
                    FacilityId = facilityId
                };

                await _roomFacilityRepository.Add(roomFacility);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _roomFacilityRepository.SaveChangesAsync();
        }
    }
}
