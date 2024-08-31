using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Users;

namespace HotelReservationApi.Services.UserRoles
{
    public interface IUserRoleService
    {
        Task AddUserToRoleAsync(UserDTO userDTO, string roleName);
        Task<bool> IsUserInRoleAsync(int userId, string roleName);
    }
}
