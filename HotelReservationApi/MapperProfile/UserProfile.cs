using AutoMapper;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User,UserViewModel>().ReverseMap();
        }

    }
}
