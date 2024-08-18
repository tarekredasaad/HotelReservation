using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.PictureSrv
{
    public interface IPictureService
    {
        Task<ResultViewModel> AddPicture(PicturesCreateDTO pictureDTO);
    }
}
