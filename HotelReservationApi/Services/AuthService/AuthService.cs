using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.ViewModel;

namespace HotelReservationApi.Services.AuthService
{
    public class AuthService: IAuthService
    {
        IRepository<User> _userRepository;

        public AuthService(IRepository<User> repository) 
        {
            _userRepository = repository;
        }


        public async Task<ResultViewModel> RegisterUserAsync(User dto)
        {
            User instructor = new User();
            //dto.password = HashPassword.Encrypt(dto.password);
            instructor = dto;
            instructor = await _userRepository.Add(instructor);
            //_unitOfWork.commit();
            ResultViewModel Result = new ResultViewModel()
            {
                StatusCode = 200,
                Data = instructor,
                Message = "You added the Instructor successfully"
            };
            return ResultViewModel.Sucess(instructor);

            //await _userRepository.AddAsync(user);
        }

        public async Task<ResultViewModel> LoginUserAsync(User dto)
        {
            User instructor =  _userRepository.First(i => i.UserName == dto.UserName);
            //var password = HashPassword.Decrypt(instructor.password);
            if (instructor == null )
            {
                return (new ResultViewModel() { StatusCode = 400, Data = "invalid username or password", Message = "invalid username or password" });
            }

            //// For simplicity, we are not using tokens here. Instead, set a session or a cookie.
            //_httpContextAccessor.HttpContext.Session.SetString("Username", instructor.username);
            return (new ResultViewModel() { StatusCode = 200, Data = instructor, Message = "you login successfully" });
        }

    }
}
