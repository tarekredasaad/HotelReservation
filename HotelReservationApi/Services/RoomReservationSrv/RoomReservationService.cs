using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.RoomFacilitySrv;

namespace HotelReservationApi.Services.RoomReservationSrv
{
    public class RoomReservationService : IRoomReservationService
    {
        IRepository<RoomReservation> _roomReservationRepository;
      
        
        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository
            
           )
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
           
            foreach (var RoomFacility in reservationDTO.RoomFacilityDTO)
            {
                foreach (var facilityId in RoomFacility.FacilityIds)
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
    }
}

                     
               
                
