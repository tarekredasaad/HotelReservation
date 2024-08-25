using AutoMapper;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.Reservations;
using HotelReservationApi.ViewModels.Rooms;

namespace HotelReservationApi.MapperProfile
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationCreateViewModel, ReservationCreateDTO>().ReverseMap();
            
            CreateMap<ReservationCreateDTO, Reservation>().ReverseMap();

            CreateMap<ReservationViewModel, ReservationDTO>().ReverseMap();

            CreateMap<Reservation, ReservationDTO>();

            CreateMap<ReservationDTO, Reservation>();
        }

    }
}
