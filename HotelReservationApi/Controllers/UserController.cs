using HotelReservationApi.Services.AuthService;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IAuthService _authService;
        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> Register(UserViewModel user)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };

            return Ok(await _authService.RegisterUserAsync(user));
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> Login(UserLoginViewModel user)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };

            return Ok(await _authService.LoginUserAsync(user));
        }

    }
}
