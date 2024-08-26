using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediator.Rooms;
using HotelReservationApi.ViewModel;
using HotelReservationApi.ViewModel.Rooms;
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

        [HttpGet]
        public async Task<ResultViewModel> GetRooms()
        {
            var roomDTOs = _roomMediator.GetRooms();
            var roomViewModels = roomDTOs.AsQueryable().Map<RoomViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = roomViewModels,
            };
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel> GetRoomById(int id)
        {
            var roomDTO = _roomMediator.GetRoomById(id);
            var roomViewModel = roomDTO.MapOne<RoomViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = roomViewModel,
            };
        }

        [HttpPost]
        public async Task<ResultViewModel> AddRoom(RoomCreateViewModel roomCreateVM)
        {
            var roomCreateDTO = roomCreateVM.MapOne<RoomCreateDTO>();
            var roomDTO = await _roomMediator.AddRoomAsync(roomCreateDTO);
            var roomVM = roomDTO.MapOne<RoomViewModel>();

            return new ResultViewModel()
            {
                StatusCode = 200,
                Data = roomVM,
            };
        }

        [HttpPut]
        public async Task<ResultViewModel> UpdateRoom(RoomViewModel roomVM)
        {
            var roomDTO = roomVM.MapOne<RoomDTO>();

            await _roomMediator.UpdateRoomAsync(roomDTO);

            return new ResultViewModel()
            {
                StatusCode = 200,
            };
        }

        [HttpDelete]
        public async Task<ResultViewModel> DeleteRoom(int id)
        {
            await _roomMediator.DeleteRoomAsync(id);

            return new ResultViewModel()
            {
                StatusCode = 200,
            };
        }
    }
}
