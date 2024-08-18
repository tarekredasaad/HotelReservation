using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Services.FacilitiesSrv;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        IFacilitiesService _facilitiesService;
        public FacilityController(IFacilitiesService facilitiesService)
        {
            _facilitiesService = facilitiesService;
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> AddFacilities(FacilitiesCreateDTO facilities)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };
            return Ok(await _facilitiesService.AddFacility(facilities));
        }
    }
}
