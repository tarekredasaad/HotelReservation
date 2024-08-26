using AutoMapper;
using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel.Facilities;


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
