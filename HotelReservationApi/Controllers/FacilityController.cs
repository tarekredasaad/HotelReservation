using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Mediators.Facilities;
using HotelReservationApi.ViewModel;
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

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> AddFacilities(FacilityCreateDTO facilities)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); 
            };

            return Ok(await _facilityMediator.AddFacility(facilities));
        }
    }
}
