using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.Pictures
{
    public interface IPictureService
    {
        void AddPicture(PictureCreateDTO pictureCreateDTO);
        void AddRange(RoomDTO roomDTO, List<PictureDTO> pictures);
        Task SaveChangesAsync();
    }
}
