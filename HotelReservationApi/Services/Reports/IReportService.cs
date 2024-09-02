using HotelReservationApi.DTOs.Reports;

namespace HotelReservationApi.Services.Reports
{
    public interface IReportService
    {
        Task<RevenueReportDTO> GetRevenueReportAsync(DateTime startDate, DateTime endDate);
        Task<CustomerReportDTO> GetCustomerReportAsync(int customerId);
    }
}
