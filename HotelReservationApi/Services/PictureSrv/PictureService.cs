using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.PictureSrv
{
    public class PictureService : IPictureService
    {
        IRepository<Pictures> _repository;

        public PictureService(IRepository<Pictures> repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> AddPicture(PicturesCreateDTO pictureDTO) 
        {
            if (pictureDTO == null) 
            {
                return ResultViewModel.Faliure();
            }
            List<Pictures> picturesList = new List<Pictures>();
            foreach (var file in pictureDTO.files)
            {
                Pictures pictures = new Pictures();
                pictures.name = file.FileName;
                pictures.ContentType = file.ContentType;
                pictures.Data = await FileHelper.ConvertToBytesAsync(file);
                picturesList.Add(pictures);
                //pictures = await _repository.Add(pictures);
            }
             await _repository.AddRange(picturesList);
            return ResultViewModel.Sucess(picturesList);
        }

    }
}
