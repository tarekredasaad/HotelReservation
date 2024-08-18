using AutoMapper;
using HotelReservationApi.DTOs.Facilities;
using HotelReservationApi.Models;

namespace HotelReservationApi.MapperProfile
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile() 
        {
          CreateMap<FacilityCreateDTO, Facilities>().ReverseMap();
        }
    }
}
