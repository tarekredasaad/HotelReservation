using AutoMapper;
using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.DTOs.RoomReservationDTO;
using HotelReservationApi.Models;

namespace HotelReservationApi.MapperProfile
{
    public class RoomReservationProfile : Profile
    {
        public RoomReservationProfile()
        {
            CreateMap<CreateReservationDTO,ReservationDTO>().ReverseMap();
            CreateMap<CreateRoomReservationDTO,ReservationDTO>().ReverseMap();
            CreateMap<CreateRoomReservationDTO, RoomReservationDTO>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();
            CreateMap<ReservationDTO, RoomReservationDTO>().ReverseMap();
            CreateMap<Reservation, RoomReservationDTO>()
                .ForMember(src=>src.ReservationId , opt=>
                opt.MapFrom(dst=>dst.Id)).ReverseMap();
            CreateMap<List<RoomReservation>, RoomReservationDTO>()
                .ForMember(dst=>dst.NumberDays , opt =>
                opt.MapFrom(src => src.Sum(rr =>
            (rr.Reservation.To - rr.Reservation.From).TotalDays)))
                .ForMember(dest => dest.Totalprice, opt =>
                    opt.MapFrom(src => src.Sum(rr => rr.Room.Price +
                                                    rr.Room.RoomFacilities.Sum(rf => rf.Facilities.Cost))))
                .ForMember(dest => dest.Rooms, opt =>
                    opt.MapFrom(src => src.Select(rr => rr.RoomId).ToHashSet()))
                .ReverseMap();
        }

    }
}
