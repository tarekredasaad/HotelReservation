using HotelReservationApi.ViewModel;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.AuthService
{
    public interface IAuthService
    {
        public Task<ResultViewModel> RegisterUserAsync(UserViewModel use);
        public Task<ResultViewModel> LoginUserAsync(UserLoginViewModel use);
    }
}
