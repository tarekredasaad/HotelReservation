using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.FacilitiesSrv;
using HotelReservationApi.Services.PictureSrv;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Mediator.Rooms
{
    public class RoomMediator : IRoomMediator
    {
        IPictureService _pictureService;
        IFacilitiesService _facilitiesService;
        IRepository<Room> _roomsRepository;
        IRepository<RoomFacilities> _RoomFacilitRepo;

        public RoomMediator(IPictureService pictureService, IFacilitiesService facilitiesService 
            ,IRepository<Room> repository 
            , IRepository<RoomFacilities> repository1)
        {
            _pictureService = pictureService;
            _facilitiesService = facilitiesService;
            _roomsRepository = repository;
            _RoomFacilitRepo = repository1;
        }

        public async Task<ResultViewModel> AddRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                return ResultViewModel.Faliure(); 
            }
            Room room = new Room();

            room = roomDTO.MapOne<Room>();

            room.Pictures = await _pictureService.pictureSRV(roomDTO.Pictures);
            List<RoomFacilities> roomFacilitiesList = new List<RoomFacilities>();
            foreach (var id in roomDTO.Facilities)
            {
                RoomFacilities roomFacilities = new RoomFacilities();
                roomFacilities.FacilityId = id;
                roomFacilities.Room = room;
                roomFacilitiesList.Add(roomFacilities);
            }

            room = await _roomsRepository.Add(room);
            await _RoomFacilitRepo.AddRange(roomFacilitiesList);
            return ResultViewModel.Sucess(room);
        }
    }
}
