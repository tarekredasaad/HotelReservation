using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Reports;

namespace HotelReservationApi.Mediators.Reports
{
    public interface IReportMediator
    {
        Task<ResultDTO> GetCustomerReportAsync(int customerId);
        Task<ResultDTO> GetRevenueReportAsync(DateTime startDate, DateTime endDate);
    }
}
