using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.Pictures
{
    public interface IPictureService
    {
        Task<PictureDTO> AddPicture(PictureCreateDTO pictureCreateDTO);
        Task<List<Picture>> pictureSRV(List<IFormFile> pictureDTO) ;
    }
}
