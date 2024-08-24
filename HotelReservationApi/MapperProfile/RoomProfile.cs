using AutoMapper;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.Rooms;

namespace HotelReservationApi.MapperProfile
{
    public class RoomProfile : Profile
    {
        public RoomProfile() 
        {
            CreateMap<RoomCreateViewModel, RoomCreateDTO>().ReverseMap();
            CreateMap<RoomCreateDTO,Room>().ReverseMap();

            CreateMap<RoomViewModel, RoomDTO>().ReverseMap();

            CreateMap<Room, RoomDTO>()
           .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.Pictures))
           .ForMember(dest => dest.Facilities, opt => opt.MapFrom(src => src.RoomFacilities.Select(rf => rf.Facility)));

            CreateMap<RoomDTO, Room>()
                .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.Pictures))
                .ForMember(dest => dest.RoomFacilities, opt => opt.MapFrom(src => src.Facilities.Select(f => new RoomFacility { FacilityId = f.Id })));


            CreateMap<RoomFacility, RoomFacilityDTO>().ReverseMap();
            CreateMap<RoomReservation, RoomReservationDTO>().ReverseMap();

        }

    }
}
