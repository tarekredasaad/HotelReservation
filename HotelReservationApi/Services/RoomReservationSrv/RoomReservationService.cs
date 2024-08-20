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
        IRepository<Room> _roomReposatory;
        public RoomReservationService(IRepository<RoomReservation> roomReservationRepository
            , IRepository<Room> roomReposatory)
        {
            _roomReservationRepository = roomReservationRepository;
            _roomReposatory = roomReposatory;
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
                var cost = _roomReposatory
                    .Get(r=>r.Id == id)
                     .Select(rr => rr.Price + rr.RoomFacilities.Sum(rf => rf.Facilities.Cost))
                     .FirstOrDefault();
                roomReservation.TotalPrice = cost;

                //var cost = _roomReservationRepository.Include(RoomFacility);
                roomReservations.Add(roomReservation);
            }

            await _roomReservationRepository.AddRange(roomReservations);
            return roomReservations;
        }
    }
}
