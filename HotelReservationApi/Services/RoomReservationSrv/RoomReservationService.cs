using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using System.Linq;

namespace HotelReservationApi.Services.RoomReservationSrv
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
                //foreach (var facilityId in RoomFacility.FacilityId)
           
            //foreach (var reservationFacility in reservationDTO.ReservationFacilityDTO)
            //{
                foreach (var facilityId in RoomFacility.FacilityId)
                {
                    RoomReservation roomReservation = new RoomReservation();
                    roomReservation.ReservationId = reservationDTO.Reservation.Id;
                    roomReservation.Reservation = reservationDTO.Reservation;
 
                   

                    roomReservation.RoomId = RoomFacility.RoomId;
 
                    roomReservation.FacilityId = facilityId;
                    roomReservations.Add(roomReservation);
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

                     
               
                
