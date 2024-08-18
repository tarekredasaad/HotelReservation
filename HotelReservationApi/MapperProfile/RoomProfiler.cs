using AutoMapper;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;

namespace HotelReservationApi.MapperProfile
{
    public class RoomProfiler : Profile
    {
        public RoomProfiler() 
        {
            CreateMap<RoomDTO, Room>()
                .ForMember(e => e.Facilities, opt => opt.Ignore())
                .ForMember(e => e.Pictures, opt => opt.Ignore())
                .ReverseMap();
        }

    }
}
