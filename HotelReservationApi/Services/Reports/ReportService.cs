using HotelReservationApi.DTOs.Reports;
using HotelReservationApi.Models;
using HotelReservationApi.Repositories;
using Stripe;

namespace HotelReservationApi.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReportService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<CustomerReportDTO> GetCustomerReportAsync(int customerId)
        {
            var reservations = _reservationRepository.Get(r => r.CustomerId == customerId)
                .Select(r => new { r.NumberDays, r.TotalPrice }).ToList();

            int totalReservations = reservations.Select(r => r.NumberDays).Sum();
            double totalSpent = reservations.Select(r => r.TotalPrice).Sum();

            return new CustomerReportDTO
            {
                CustomerId = customerId,
                TotalReservations = totalReservations,
                TotalSpent = totalSpent
            };
        }

        public async Task<RevenueReportDTO> GetRevenueReportAsync(DateTime startDate, DateTime endDate)
        {
            var reservations = _reservationRepository.Get(r => r.From == startDate && r.To == endDate)
                .Select(r => new { r.TotalPrice }).ToList();

            double totalRevenue = reservations.Select(r => r.TotalPrice).Sum();

            return new RevenueReportDTO
            {
                StartDate= startDate,
                EndDate= endDate,
                TotalRevenue = totalRevenue
            };
        }
    }
}
