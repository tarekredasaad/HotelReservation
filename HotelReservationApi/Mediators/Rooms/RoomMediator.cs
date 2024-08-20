using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Services.Pictures;
using HotelReservationApi.Services.RoomFacilities;
using HotelReservationApi.Services.Rooms;

namespace HotelReservationApi.Mediators.Rooms
{
    public class RoomMediator : IRoomMediator
    {
        private readonly IPictureService _pictureService;
        private readonly IRoomService _roomService;
        private readonly IRoomFacilityService _roomFacilityService;

        public RoomMediator(IPictureService pictureService, IRoomService roomService, IRoomFacilityService roomFacilityService)
        {
            _pictureService = pictureService;
            _roomFacilityService = roomFacilityService;
            _roomService = roomService;
        }

        public async Task<RoomDTO> AddRoom(RoomCreateDTO roomCreateDTO)
        {
            var room = await _roomService.AddRoom(roomCreateDTO);
            
            await _roomService.SaveChangesAsync();

            var roomDTO = room.MapOne<RoomDTO>();

            return roomDTO;

            //room.Pictures = await _pictureService.pictureSRV(roomCreateDTO.Pictures);

            //RoomFacilityDTO roomFacilityDTO = new RoomFacilityDTO();
            //roomFacilityDTO.FacilityIds = roomCreateDTO.Facilities.ToList();
            //roomFacilityDTO.RoomId = room.Id;

            //await _roomFacilityService.GetRoomFacilities(roomFacilityDTO);

            //return ResultViewModel.Sucess(room);
        }

        public List<RoomDTO> GetRooms()
        {
            var roomDTOs = _roomService.GetRooms().ToList();

            return roomDTOs;
        }

        public void RemoveRoom(int id)
        {
            _roomService.DeleteRoom(id);
        }

        public void UpdateRoom(RoomDTO roomDTO)
        {
            _roomService.UpdateRoom(roomDTO);
        }
    }
}
