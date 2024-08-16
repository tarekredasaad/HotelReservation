﻿using HotelReservationApi.Services.AuthService;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IAuthService _authService;
        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<ResultViewModel>> Register(UserViewModel user)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };

            return Ok(await _authService.RegisterUserAsync(user));
        }
        [HttpPost("LoginUser")]

        public async Task<ActionResult<ResultViewModel>> Login(UserLoginViewModel user)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };

            return Ok(await _authService.LoginUserAsync(user));
        }

    }
}