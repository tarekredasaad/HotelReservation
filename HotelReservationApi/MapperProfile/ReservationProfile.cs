using AutoMapper;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;

namespace HotelReservationApi.MapperProfile
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationDTO, Reservation>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();
        }

    }
}
