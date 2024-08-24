using AutoMapper;
using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels;
using HotelReservationApi.ViewModels.Rooms;

namespace HotelReservationApi.MapperProfile
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile() 
        {
            CreateMap<FacilityCreateViewModel, FacilityCreateDTO>().ReverseMap();
            CreateMap<FacilityCreateDTO, Facility>().ReverseMap();

            CreateMap<FacilityViewModel, FacilityDTO>().ReverseMap();

            CreateMap<FacilityCreateDTO, Facility>().ReverseMap();
            CreateMap<FacilityDTO, Facility>().ReverseMap();
        }
    }
}
