using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.PictureSrv
{
    public interface IPictureService
    {
        Task<ResultViewModel> AddPicture(PicturesCreateDTO pictureDTO);

        Task<List<Pictures>> pictureSRV(List<IFormFile> pictureDTO) ;
    }
}
