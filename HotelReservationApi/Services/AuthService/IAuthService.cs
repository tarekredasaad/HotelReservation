using HotelReservationApi.ViewModel;
using HotelReservationApi.Models;

namespace HotelReservationApi.Services.AuthService
{
    public interface IAuthService
    {
        public Task<ResultViewModel> RegisterUserAsync(User dto);
        public Task<ResultViewModel> LoginUserAsync(User dto);
    }
}
