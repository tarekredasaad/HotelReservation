using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Reports;
using HotelReservationApi.Services.Reports;

namespace HotelReservationApi.Mediators.Reports
{
    public class ReportMediator : IReportMediator
    {
        private readonly IReportService _reportService;

        public ReportMediator(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<ResultDTO> GetCustomerReportAsync(int customerId)
        {
            var customerReportDTO = await _reportService.GetCustomerReportAsync(customerId);

            if (customerReportDTO is null)
            {
                return ResultDTO.Faliure("No customers found.");
            }

            return ResultDTO.Sucess(customerReportDTO);
        }

        public async Task<ResultDTO> GetRevenueReportAsync(DateTime startDate, DateTime endDate)
        {
            var revenueReportDTO = await _reportService.GetRevenueReportAsync(startDate, endDate);

            if (revenueReportDTO is null)
            {
                return ResultDTO.Faliure("No revenue data found for the specified date range.");
            }

            return ResultDTO.Sucess(revenueReportDTO);
        }
    }
}
