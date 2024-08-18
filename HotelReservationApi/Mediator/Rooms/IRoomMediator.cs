using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Mediator.Rooms
{
    public interface IRoomMediator
    {
        Task<ResultViewModel> AddRoom(RoomDTO roomDTO);
    }
}
