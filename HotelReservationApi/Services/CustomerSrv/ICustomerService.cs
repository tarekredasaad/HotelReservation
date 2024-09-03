using HotelReservationApi.DTOs.Users;

namespace HotelReservationApi.Services.CustomerSrv
{
    public interface ICustomerService
    {
       Task AddCustomer(CustomerDTO customerDTO);
    }
}
