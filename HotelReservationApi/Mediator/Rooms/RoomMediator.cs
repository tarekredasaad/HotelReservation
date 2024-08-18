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

        public RoomMediator(IPictureService pictureService, IFacilitiesService facilitiesService 
            ,IRepository<Room> repository)
        {
            _pictureService = pictureService;
            _facilitiesService = facilitiesService;
            _roomsRepository = repository;
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
                room.Facilities =(List<Facilities>) await _facilitiesService.GetFacilities(roomDTO.Facilities);
            room = await _roomsRepository.Add(room);
            return ResultViewModel.Sucess(room);
        }
    }
}
