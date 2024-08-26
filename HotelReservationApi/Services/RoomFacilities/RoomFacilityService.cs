﻿using HotelReservationApi.DTOs.Reservations;
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

        public async Task<double> CostRoom(HashSet<ReservationFacilityDTO> reservationFacilityDTOs)
        {
            double roomCost = 0;
            double cost = 0;

            foreach (var reservationFacilityDTO in reservationFacilityDTOs)
            {
                double facilityCost = 0;

                foreach(var id in reservationFacilityDTO.FacilitiesIDs)
                {
                    var roomFacility = await _roomFacilityRepository.
                        GetAll(r => r.RoomId == reservationFacilityDTO.RoomId && r.FacilityId == id, r => r.Room, r => r.Facility);

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
