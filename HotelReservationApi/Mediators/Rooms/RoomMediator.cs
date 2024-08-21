using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
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

        public IEnumerable<RoomDTO> GetRooms()
        {
            var roomDTOs = _roomService.GetRooms();

            return roomDTOs;
        }

        public async Task<RoomDTO> AddRoomAsync(RoomCreateDTO roomCreateDTO)
        {
            var room = await _roomService.AddRoom(roomCreateDTO);
            await _roomService.SaveChangesAsync();

            await _roomFacilityService.AddRange(room.Id, roomCreateDTO.FacilityIDs);
            await _roomFacilityService.SaveChangesAsync();

            await _pictureService.AddRange(roomCreateDTO.Pictures);
            await _pictureService.SaveChangesAsync();

            var roomDTO = room.MapOne<RoomDTO>();

            return roomDTO;
        }

        public RoomDTO GetRoomById(int id)
        {
            var roomDTO = _roomService.GetRoomById(id);
            return roomDTO;
        }

        public async Task DeleteRoomAsync(int id)
        {
            _roomService.DeleteRoom(id);
            await _roomService.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(RoomDTO roomDTO)
        {
            _roomService.UpdateRoom(roomDTO);
            await _roomService.SaveChangesAsync();
        }
    }
}
