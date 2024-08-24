using AutoMapper;
using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Models;

namespace HotelReservationApi.MapperProfile
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<PictureCreateDTO, Picture>().ReverseMap();
            CreateMap<PictureDTO, Picture>().ReverseMap();
        }
    }
}
