using AutoMapper;
using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.Rooms;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel.Reservations;
using HotelReservationApi.ViewModel.RoomFacilities;
using HotelReservationApi.ViewModel.Rooms;

namespace HotelReservationApi.MapperProfile
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomCreateViewModel, RoomCreateDTO>().ReverseMap();
            CreateMap<RoomCreateDTO, Room>().ReverseMap();

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

            CreateMap<ReservationViewModel, ReservationDTO>().ReverseMap();

            CreateMap<RoomFacilityViewModel, RoomFacilityDTO>().ReverseMap();
        }

    }
}
