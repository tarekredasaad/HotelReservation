using HotelReservationApi.DTOs.Users;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.CustomerSrv
{
    public class CustomerService: ICustomerService
    {
        IRepository<Customer> _customerRepo;

        public CustomerService(IRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task AddCustomer(CustomerDTO customerDTO)
        {
            Customer customer = customerDTO.MapOne<Customer>();
            customer =  await _customerRepo.AddAsync(customer);

        }

        public async Task<int> GetCustomerId(int userId)
        {
            Customer customer = await _customerRepo.First(x => x.UserId == userId);
            return customer.Id;
        }
    }
}
