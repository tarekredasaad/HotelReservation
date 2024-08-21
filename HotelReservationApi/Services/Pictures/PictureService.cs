using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.Pictures
{
    public class PictureService : IPictureService
    {
        IRepository<Picture> _pictureRepository;

        public PictureService(IRepository<Picture> repository)
        {
            _pictureRepository = repository;
        }

        public async Task AddPicture(PictureCreateDTO pictureCreateDTO)
        {
            var picture = pictureCreateDTO.MapOne<Picture>();
            await _pictureRepository.Add(picture);
            await _pictureRepository.SaveChangesAsync();
        }

        public async Task AddRange(List<PictureDTO> pictures)
        {
            foreach(var pictureDTO in pictures)
            {
                var picture = pictureDTO.MapOne<Picture>();
                await _pictureRepository.Add(picture);
            }

            await _pictureRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _pictureRepository.SaveChangesAsync();
        }
    }
}
