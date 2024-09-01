using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.DTOs.Rooms;

namespace HotelReservationApi.Services.Pictures
{
    public interface IPictureService
    {
        void AddPicture(PictureCreateDTO pictureCreateDTO);
        void AddRange(RoomDTO roomDTO, List<PictureDTO> pictures);
        Task SaveChangesAsync();
    }
}
