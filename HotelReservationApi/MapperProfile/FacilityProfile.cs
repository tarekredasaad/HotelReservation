using AutoMapper;
using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.Facilities;
using HotelReservationApi.ViewModels.Rooms;
using HotelReservationApi.ViewModels.Facilities;


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
