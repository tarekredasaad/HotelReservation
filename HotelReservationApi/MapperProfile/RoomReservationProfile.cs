using AutoMapper;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservations;

namespace HotelReservationApi.MapperProfile
{
    public class RoomReservationProfile : Profile
    {
        public RoomReservationProfile()
        {
            CreateMap<ReservationCreateDTO, ReservationDTO>().ReverseMap();
            CreateMap<RoomReservationCreateDTO, ReservationDTO>().ReverseMap();
            CreateMap<RoomReservationCreateDTO, RoomReservationDTO>().ReverseMap();
            
            CreateMap<ReservationDTO, RoomReservationDTO>().ReverseMap();
        }

    }
}
