using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Auth;
using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> CreateUserAsync(UserRegisterDTO registerDTO)
        {
            var user = registerDTO.MapOne<User>();

            user.PasswordHash = CreatePasswordHash(registerDTO.Password);

            user = await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            var userDTO = user.MapOne<UserDTO>();

            return userDTO;
        }
        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = userDTO.MapOne<User>();
            _userRepository.Update(user);
        }

        public async Task<UserDTO> FindUserByEmailAsync(string email)
        {
            var user = await _userRepository.First(u => u.Email == email);
            var userDTO = user.MapOne<UserDTO>();

            return userDTO;
        }

        public async Task<UserDTO> FindUserByNameAsync(string username)
        {
            var user = await _userRepository.First(u => u.UserName == username);
            var userDTO = user.MapOne<UserDTO>();

            return userDTO;
        }

        public async Task<bool> CheckUserPasswordAsync(UserDTO userDTO, string password)
        {
            var user = await _userRepository.First(u => u.Email == userDTO.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return false;
            }

            return true;
        }

        private string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync();
        }
    }
}
