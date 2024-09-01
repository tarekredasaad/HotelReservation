using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.RoomReservationFacilities
{
    public class RoomReservationFacilityService : IRoomReservationFacilityService
    {
        IRepository<RoomReservationFacility> _repository;

        public RoomReservationFacilityService(IRepository<RoomReservationFacility> repository)
        {
            _repository = repository;
        }
        public async Task<List<RoomReservationFacility>>
            Add(List<RoomReservation> roomReservations
            , HashSet<RoomFacilityDTO> roomFacilityDTOs)
        {
            List<RoomReservationFacility> roomReservationFacilities =
                new List<RoomReservationFacility>();
            foreach (var item in roomReservations)
            {
                RoomReservationFacility roomReservationFacility =
                    new RoomReservationFacility();
                roomReservationFacility.RoomReservation = item;

                foreach (var facility in roomFacilityDTOs)
                {
                    foreach(int id in facility.FacilityId)
                    {

                        roomReservationFacility.FacilityId = id;
                    }
                }
                    roomReservationFacilities.Add(roomReservationFacility);
            }

            await _repository.AddRange(roomReservationFacilities);
            return roomReservationFacilities;
        }
    }
}
