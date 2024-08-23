using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.RoomReservationSrv
{
    public class RoomReservationService : IRoomReservationService
    {
        IRepository<RoomReservation> _roomReservationRepository;
        IRepository<RoomFacility> _roomFacilityReposatory;
        IRepository<Facility> _facilityRepository;
        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository
            , IRepository<RoomFacility> roomReposatory
            ,IRepository<Facility> facilityRepository)
        {
            _roomReservationRepository = roomReservationRepository;
            _roomFacilityReposatory = roomReposatory;
            _facilityRepository = facilityRepository;
        }

        public async Task<List<RoomReservation>> AddRoomReservation(RoomReservationDTO reservationDTO)
        {
            if(reservationDTO == null)
            {
                return null;
            }

            List<RoomReservation> roomReservations = new List<RoomReservation>();
            //reservationDTO.MapOne<List<RoomReservation>>();
            //List<RoomReservation> roomReservations2 = reservationDTO.MapOne<List<RoomReservation>>();
            foreach (var id in reservationDTO.Rooms)
            {
                RoomReservation roomReservation = new RoomReservation();
                roomReservation.RoomId = id;
                roomReservation.ReservationId = reservationDTO.ReservationId;
                roomReservation.IsReserved = true;
                var roomFacilities = await _roomFacilityReposatory
                    .GetAll(r => r.RoomId == id, r=>r.Facilities , r=>r.Room);
                  //var price =  cost.ToList();
                //var facilities = cost.FirstOrDefault();
                double sum = roomFacilities.Sum(r=>r.Room.Price + r.Facilities.Cost);

                roomReservation.NumberDays = 5;
                     
                roomReservation.TotalPrice =  sum - roomFacilities.FirstOrDefault().Room.Price;

                //var cost = _roomReservationRepository.Include(RoomFacility);
                roomReservations.Add(roomReservation);
            }

            await _roomReservationRepository.AddRange(roomReservations);
            return roomReservations;
        }
    }
}
