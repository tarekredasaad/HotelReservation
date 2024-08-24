using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.AuthService
{
    public class AuthService: IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor) 
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResultViewModel> RegisterUserAsync(UserViewModel dto)
        {
            User user = new User();
            dto.Password = HashPassword.Encrypt(dto.Password);
            user = dto.MapOne<User>();
            user = await _userRepository.AddAsync(user);
            
            //Staff staff = new Staff();
            //if(dto.GroupId == 1)
            //{
            //    staff.User = user;
                
            //}
            
            return ResultViewModel.Sucess(user);
        }

        public async Task<ResultViewModel> LoginUserAsync(UserLoginViewModel dto)
        {
            User user =  _userRepository.First(i => i.UserName == dto.UserName);

            var password = HashPassword.Decrypt(user.Password);

            if (user == null || password != null )
            {
                return (ResultViewModel.Faliure());
            }
           
            _httpContextAccessor.HttpContext.Session.SetString("UserName", user.UserName);

            return ( ResultViewModel.Sucess(user));
        }

    }
}
