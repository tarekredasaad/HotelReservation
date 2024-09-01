using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.Pictures
{
    public class PictureService : IPictureService
    {
        IRepository<Picture> _pictureRepository;

        public PictureService(IRepository<Picture> repository)
        {
            _pictureRepository = repository;
        }

        public void AddPicture(PictureCreateDTO pictureCreateDTO)
        {
            var picture = pictureCreateDTO.MapOne<Picture>();
            _pictureRepository.Add(picture);
        }

        public void AddRange(RoomDTO roomDTO, List<PictureDTO> pictures)
        {
            foreach (var pictureDTO in pictures)
            {
                var picture = pictureDTO.MapOne<Picture>();
                picture.RoomId = roomDTO.Id;
                _pictureRepository.Add(picture);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _pictureRepository.SaveChangesAsync();
        }
    }
}
