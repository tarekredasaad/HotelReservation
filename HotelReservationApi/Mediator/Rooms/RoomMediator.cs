using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.FacilitiesSrv;
using HotelReservationApi.Services.PictureSrv;
using HotelReservationApi.Services.RoomFacilitySrv;
using HotelReservationApi.Services.RoomsSrv;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Mediator.Rooms
{
    public class RoomMediator : IRoomMediator
    {
        IPictureService _pictureService;
      
        IRoomService _roomService;
      
        IRoomFacilityService _roomFacilityService;

        public RoomMediator(IPictureService pictureService 
             
            ,IRoomService roomService,
            IRoomFacilityService roomFacilityService
            )
        {
            _pictureService = pictureService;
          
         
           
            _roomFacilityService = roomFacilityService;
            _roomService = roomService;
        }

        public async Task<ResultViewModel> AddRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                return ResultViewModel.Faliure(); 
            }
            Room room = new Room();
            RoomCreateDTO roomCreateDTO = roomDTO.MapOne<RoomCreateDTO>();
           
            room.Pictures = await _pictureService.pictureSRV(roomDTO.Pictures);
            room = await _roomService.AddRoom(roomCreateDTO);

            await _roomService.SaveChange();

            
            RoomFacilityDTO roomFacilityDTO = new RoomFacilityDTO();
            roomFacilityDTO.FacilityIds = roomDTO.Facilities.ToList();
            roomFacilityDTO.RoomId = room.Id;

            await _roomFacilityService.GetRoomFacilities(roomFacilityDTO);

            

            return ResultViewModel.Sucess(room);
        }
    }
}
