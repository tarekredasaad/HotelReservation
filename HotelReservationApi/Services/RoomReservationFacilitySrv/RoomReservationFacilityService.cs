using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomReservationFacilitySrv
{
    public class RoomReservationFacilityService : IRoomReservationFacilityService
    {
        IRepository<RoomReservationFacilities> _repository;

        public RoomReservationFacilityService(IRepository<RoomReservationFacilities> repository)
        {
            _repository = repository;
        }
        public async Task<List<RoomReservationFacilities>>
            Add(List<RoomReservation> roomReservations
            , HashSet<RoomFacilityDTO> roomFacilityDTOs)
        {
            List<RoomReservationFacilities> roomReservationFacilities =
                new List<RoomReservationFacilities>();
            foreach (var item in roomReservations)
            {
                RoomReservationFacilities roomReservationFacility =
                    new RoomReservationFacilities();
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
