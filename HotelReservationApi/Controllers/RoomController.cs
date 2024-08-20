using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Mediators.Rooms;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomMediator _roomMediator;

        public RoomController(IRoomMediator roomMediator)
        {
            _roomMediator = roomMediator;
        }

        [HttpPost]

        public async Task<ActionResult<ResultViewModel>> AddRoom(RoomCreateDTO roomDTO)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); 
            };

            return Ok(await _roomMediator.AddRoom(roomDTO));
        }
    }
}
