﻿using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediators.Facilities;
using HotelReservationApi.ViewModels;
using HotelReservationApi.ViewModels.Facilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityMediator _facilityMediator;

        public FacilityController(IFacilityMediator facilityMediator)
        {
            _facilityMediator = facilityMediator;
        }

        [HttpGet]
        public async Task<ResultViewModel> GetFacilities()
        {
            var facilityDTOs = _facilityMediator.GetFacilities();
            var facilityViewModels = facilityDTOs.AsQueryable().Map<FacilityViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = facilityViewModels,
            };
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel> GetfacilityById(int id)
        {
            var facilityDTO = await _facilityMediator.GetFacilityById(id);
            var facilityViewModel = facilityDTO.MapOne<FacilityViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = facilityViewModel,
            };
        }

        [HttpPost]
        [Authorize(Policy = "Staff")]
        public async Task<ActionResult<ResultViewModel>> AddFacilities(FacilityCreateViewModel facility)
        {
            var facilityCreateDTO = facility.MapOne<FacilityCreateDTO>();

            var facilityDTO = await _facilityMediator.AddFacility(facilityCreateDTO);

            var facilityViewModel = facilityDTO.MapOne<FacilityViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = facilityViewModel,
            };
        }
    }
}
