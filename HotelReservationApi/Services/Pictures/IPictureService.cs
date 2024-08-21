using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.Pictures
{
    public interface IPictureService
    {
        Task AddPicture(PictureCreateDTO pictureCreateDTO);
        Task AddRange(List<PictureDTO> pictures);
        Task SaveChangesAsync();
    }
}
