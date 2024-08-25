﻿using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.FacilitiesSrv
{
    public interface IFacilitiesService
    {
        Task<IEnumerable<Facility>> GetFacilities(HashSet<int> ints);
        Task<Facility> GetFacilitiesById(int id);
        Task<ResultViewModel> AddFacility(FacilitiesCreateDTO facilitiesCreateDTO);
        void UpdateFacility(FacilitiesDTO facilitiesDTO);
        void RemoveFacility(int id);
    }
}