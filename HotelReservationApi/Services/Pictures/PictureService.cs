using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.Pictures
{
    public class PictureService : IPictureService
    {
        IRepository<Picture> _repository;

        public PictureService(IRepository<Picture> repository)
        {
            _repository = repository;
        }

        public Task<PictureDTO> AddPicture(PictureCreateDTO pictureCreateDTO)
        {
            throw new NotImplementedException();
        }

        //public async Task<PictureDTO> AddPicture(PictureCreateDTO pictureCreateDTO)
        //{
        //    Picture picture = pictureCreateDTO.MapOne<PictureCreateDTO>();

        //    picture.name = picture.FileName;
        //    picture.ContentType = picture.ContentType;
        //    picture.Data = await FileHelper.ConvertToBytesAsync(picture);

        //    picture = await _repository.Add(picture);

        //    var pictureDTO = picture.MapOne<PictureDTO>();

        //    return pictureDTO;
        //}

        public async Task<List<Picture>> pictureSRV(List<IFormFile> pictureDTO)
        {
            if (pictureDTO == null)
            {
                return null;
            }

            List<Picture> picturesList = new List<Picture>();

            foreach (var file in pictureDTO)
            {
                Picture picture = new Picture();
                picture.name = file.FileName;
                picture.ContentType = file.ContentType;
                picture.Data = await FileHelper.ConvertToBytesAsync(file);
                picturesList.Add(picture);
                //pictures = await _repository.Add(pictures);
            }
           
            return (picturesList);
        }
    }
}
