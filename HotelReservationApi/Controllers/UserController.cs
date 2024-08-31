using HotelReservationApi.DTOs.Auth;
using HotelReservationApi.Helper;
using HotelReservationApi.Mediators.Users;
using HotelReservationApi.ViewModel;
using HotelReservationApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserMediator _userMediator;

        public UserController(IUserMediator userMediator)
        {
            _userMediator = userMediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultViewModel> Register(UserRegisterViewModel registerVM)
        {
            var userRegisterDTO = registerVM.MapOne<UserRegisterDTO>();
            var result = await _userMediator.RegisterAsync(userRegisterDTO);

            return ResultViewModel.Sucess(result.Data, result.Message);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultViewModel> Login(UserLoginViewModel loginVM)
        {
            var userLoginDTO = loginVM.MapOne<UserLoginDTO>();
            var result = await  _userMediator.LoginAsync(userLoginDTO);

            return ResultViewModel.Sucess(result.Data, result.Message);
        }
    }
}
