using HotelReservationApi.DTOs;

namespace HotelReservationApi.Services.Roles
{
    public interface IRoleService
    {
        Task<ResultDTO> CreateRoleAsync(string roleName);
        Task SaveChangesAsync();
    }
}
