using AutoMapper;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.MapperProfile
{
    public class RoomProfiler : Profile
    {
        public RoomProfiler() 
        {
            CreateMap<RoomCreateDTO,RoomDTO>().ReverseMap();
            CreateMap<RoomCreateDTO,Room>().ReverseMap();
            CreateMap<RoomDTO, Room>()
                .ForMember(e => e.RoomFacilities, opt => opt.Ignore())
                .ForMember(e => e.Pictures, opt => opt.Ignore())
                .ReverseMap();
        }

    }
}
