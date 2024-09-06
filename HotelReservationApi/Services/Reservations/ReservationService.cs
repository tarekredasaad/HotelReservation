using HotelReservationApi.DTOs.Reservations;
using HotelReservationApi.Helper;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
using HotelReservationApi.Services.CustomerSrv;
using HotelReservationApi.Services.Users;

namespace HotelReservationApi.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        IRepository<Reservation> _repository;
        IHttpContextAccessor _httpContextAccessor;
        IUserService _userService;
        ICustomerService _customerService;

        public ReservationService(IRepository<Reservation> repository
            , IHttpContextAccessor httpContextAccessor
            ,ICustomerService customerService
            , IUserService userService)
        {

            _repository = repository;
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<Reservation> AddReservation(ReservationDTO reservationDTO)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");

            Reservation reservation = reservationDTO.MapOne<Reservation>();
            int userId = await _userService.GetUserIdFromToken(token);
            reservation.CustomerId = await _customerService.GetCustomerId(userId);

            reservation.NumberDays = (reservationDTO.To - reservationDTO.From).Days;

            reservation =await _repository.AddAsync(reservation);

            return reservation;
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
        public async Task<List<Reservation>> GetAll()
        {
            List<Reservation> reservations = _repository.GetAll().ToList();
            return reservations;
        }
        public async Task<Reservation> Get(int id)
        {
            Reservation reservation = _repository.GetByID(id);
            return reservation;
        }

        public async Task<Reservation> Update(ReservationDTO reservationDTO, int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");

            Reservation reservation = await Get(id);
            if(reservation == null)
            {
                return default;
            }
             reservation = reservationDTO.MapOne<Reservation>();
            int userId = await _userService.GetUserIdFromToken(token);
            reservation.CustomerId = await _customerService.GetCustomerId(userId);
            reservation.Id = id;
            reservation.NumberDays = (reservationDTO.To - reservationDTO.From).Days;

            reservation = _repository.Update(reservation);

            return reservation;
        }
        public async Task<Reservation> UpdateToConfirm(Reservation reservation)
        {
            Reservation reservation1 =  _repository.Update(reservation);
            return reservation1;
        }
        public async Task<List<Reservation>> GetReservationAvailable( SearchReservationDTO searchReservationDTO)
        {
            var reservation =await _repository.GetAll(r => 
                 r.To < searchReservationDTO.To && r.From > searchReservationDTO.From);
                       
            return reservation;
        }
               
    }
}
