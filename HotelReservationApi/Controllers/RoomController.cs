using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Mediator.Rooms;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomMediator roomMediator;
        public RoomController(IRoomMediator roomMediator)
        {
            this.roomMediator = roomMediator;
        }

        [HttpPost]

        public async Task<ActionResult<ResultViewModel>> AddRoom(RoomDTO roomDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };
            return Ok(await roomMediator.AddRoom(roomDTO));
        }
    }
}
