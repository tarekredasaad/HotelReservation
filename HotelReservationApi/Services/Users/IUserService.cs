using HotelReservationApi.DTOs.Users;
using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Auth;

namespace HotelReservationApi.Services.Users
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(UserRegisterDTO registerDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task<UserDTO> FindUserByEmailAsync(string email);
        Task<UserDTO> FindUserByNameAsync(string username);
        Task<bool> CheckUserPasswordAsync(UserDTO user, string password);
        Task SaveChangesAsync();
    }
}
