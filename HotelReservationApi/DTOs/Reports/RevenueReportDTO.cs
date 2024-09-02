namespace HotelReservationApi.DTOs.Reports
{
    public class RevenueReportDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalRevenue { get; set; }
    }
}
