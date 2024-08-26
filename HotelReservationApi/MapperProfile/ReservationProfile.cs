using AutoMapper;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel.Reservations;

namespace HotelReservationApi.MapperProfile
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationViewModel, ReservationDTO>().ReverseMap();
           
            CreateMap<CreateReservationDTO, Reservation>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();

            CreateMap<ReservationFacilityViewModel, ReservationFacilityDTO>().ReverseMap();
        }

    }
}
