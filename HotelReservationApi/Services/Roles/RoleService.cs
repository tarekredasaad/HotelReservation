using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResultDTO> CreateRoleAsync(string roleName)
        {
            Role role = new Role
            {
                Name = roleName,    
            };

            var result = _roleRepository.Add(role);

            return new ResultDTO
            {
                Data = result,
            };
        }

        public async Task SaveChangesAsync()
        {
            _roleRepository.SaveChangesAsync();
        }
    }
}
