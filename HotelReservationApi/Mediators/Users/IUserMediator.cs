using HotelReservationApi.DTOs.Auth;
using HotelReservationApi.DTOs;

namespace HotelReservationApi.Mediators.Users
{
    public interface IUserMediator
    {
        Task<ResultDTO> RegisterAsync(UserRegisterDTO registerDTO);
        Task<ResultDTO> LoginAsync(UserLoginDTO loginDTO);
    }
}
