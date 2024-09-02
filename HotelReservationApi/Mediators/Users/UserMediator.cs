using HotelReservationApi.DTOs.Auth;
using HotelReservationApi.DTOs;
using HotelReservationApi.Models;
using HotelReservationApi.Services.Users;
using HotelReservationApi.Services.Roles;
using HotelReservationApi.Helper;
using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Services.UserRoles;
using HotelReservationApi.Services;

namespace HotelReservationApi.Mediators.Users
{
    public class UserMediator : IUserMediator
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public UserMediator(IUserService userService, 
            IRoleService roleService, 
            IUserRoleService userRoleService)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task<ResultDTO> LoginAsync(UserLoginDTO loginDTO)
        {
            var userDTO = await _userService.FindUserByEmailAsync(loginDTO.Email);

            if (userDTO is null || !await _userService.CheckUserPasswordAsync(userDTO, loginDTO.Password))
            {
                return ResultDTO.Faliure("Email or Password is incorrect");
            }

            var token = TokenGenerator.GenerateToken(userDTO);
            
            TokenGenerator.token = token;
            return ResultDTO.Sucess(token, "Login Successed!");
        }

        public async Task<ResultDTO> RegisterAsync(UserRegisterDTO registerDTO)
        {
            var userDTO = await _userService.FindUserByEmailAsync(registerDTO.Email);

            if (userDTO is not null)
            {
                return ResultDTO.Faliure("Email is already registered!");
            }

            userDTO = await _userService.FindUserByNameAsync(registerDTO.UserName);

            if (userDTO is not null)
            {
                return ResultDTO.Faliure("Username is alerady registered!");
            }

            var userCreatedDTO = await _userService.CreateUserAsync(registerDTO);

            await _userRoleService.AddUserToRoleAsync(userCreatedDTO, registerDTO.Role);

            var token = TokenGenerator.GenerateToken(userCreatedDTO);
        
            return ResultDTO.Sucess(token, "User Registration Successed");
        }
    }
}
