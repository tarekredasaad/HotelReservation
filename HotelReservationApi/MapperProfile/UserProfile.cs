using AutoMapper;
using HotelReservationApi.DTOs.Auth;
using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModel;
using HotelReservationApi.ViewModels.Auth;

namespace HotelReservationApi.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserLoginViewModel, UserLoginDTO>();
            CreateMap<UserRegisterViewModel, UserRegisterDTO>();

            CreateMap<UserRegisterDTO, User>();

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Claims, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.Staff, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore());

            CreateMap<User, UserDTO>()
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles != null && src.UserRoles.Any()
                ? src.UserRoles.First().Role.Name : string.Empty));
        }

    }
}
