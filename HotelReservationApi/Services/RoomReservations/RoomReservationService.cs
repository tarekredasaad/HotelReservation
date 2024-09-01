using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.RoomReservations
{
    public class RoomReservationService : IRoomReservationService
    {
        private readonly IRepository<RoomReservation> _roomReservationRepository;

        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }

        public  async Task<List<RoomReservation>> AddRoomReservation(RoomReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return null;
            }

            List<RoomReservation> roomReservations = new List<RoomReservation>();

            foreach (var RoomFacility in reservationDTO.ReservationFacilityDTO)
            {
                    RoomReservation roomReservation = new RoomReservation();
                    roomReservation.ReservationId = reservationDTO.Reservation.Id;
                    roomReservation.Reservation = reservationDTO.Reservation;
 
                    roomReservation.RoomId = RoomFacility.RoomId;

                    roomReservations.Add(roomReservation);

                foreach (var facilityId in RoomFacility.FacilitiesIDs)
                {
                    RoomReservationFacility roomReservationFacilities = new RoomReservationFacility();
                    roomReservationFacilities.FacilityId = facilityId;
                    roomReservationFacilities.RoomReservation = roomReservation;

                }
            }
            

            await _roomReservationRepository.AddRange(roomReservations);
            return roomReservations;
        }

        public async Task<List<RoomReservation>> getRooms()
        {
            List<RoomReservation> rooms = _roomReservationRepository.GetAll(r=>r.Room)
                .ToList();
                //.Contains((RoomReservation)(searchReservationDTO.RoomIds as IEnumerable<int>));//.Contains((IEnumerable<int>) searchReservationDTO.RoomIds);
            //var result = rooms.Contains(searchReservationDTO.RoomIds);

            return rooms;
        }
    }
}

                     
               
                
