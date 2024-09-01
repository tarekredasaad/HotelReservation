using AutoMapper;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.Reservations;

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
            CreateMap<ReservationViewModel, ReservationDTO>().ReverseMap();
           
            CreateMap<ReservationCreateDTO, Reservation>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();

            CreateMap<ReservationFacilityViewModel, ReservationFacilityDTO>().ReverseMap();
        }

    }
}
