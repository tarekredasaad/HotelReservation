using AutoMapper;
using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
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
                .ForMember(dest => dest.RoomFacilities, opt => opt.MapFrom(src => src.Facilities.Select(f => new RoomFacility { FacilityId = f.Id })))
                .AfterMap((src, dest) =>
                {
                    foreach (var roomFacility in dest.RoomFacilities)
                    {
                        roomFacility.RoomId = dest.Id;
                    }
                });

            CreateMap<RoomFacility, RoomFacilityDTO>().ReverseMap();

            CreateMap<RoomReservation, RoomReservationDTO>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.Number))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room.Type))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Room.Price))
                .ForMember(dest => dest.Facilities, opt => opt.Ignore());
        }

    }
}
