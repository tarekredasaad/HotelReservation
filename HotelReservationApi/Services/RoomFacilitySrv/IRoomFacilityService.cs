﻿using HotelReservationApi.DTOs;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.RoomFacilitySrv
{
    public interface IRoomFacilityService
    {

        Task AddRoomFacilities(RoomFacilityDTO roomFacilityDTO);
        double costRoom(HashSet<RoomFacilityDTO> roomFacilityDTOs);
    }
}
