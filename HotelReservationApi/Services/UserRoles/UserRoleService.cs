using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.UserRoles
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<Role> _roleRepository;

        public UserRoleService(IRepository<UserRole> userRoleRepository, IRepository<Role> roleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public async Task AddUserToRoleAsync(UserDTO userDTO, string roleName)
        {
            var role = await _roleRepository.First(r => r.Name == roleName);

            var userRole = new UserRole 
            { 
                UserId = userDTO.Id,
                RoleId = role.Id
            };

            _userRoleRepository.Add(userRole);
            await _userRoleRepository.SaveChangesAsync();
        }

        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            var role = _roleRepository.First(r => r.Name == roleName);

            var userRole = _userRoleRepository.First(ur => ur.UserId == userId && ur.RoleId == role.Id);

            if (userRole is not null) 
            {
                return true;
            }

            return false;
        }
    }
}
