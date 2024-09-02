namespace HotelReservationApi.DTOs.Reports
{
    public class CustomerReportDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalReservations { get; set; }
        public double TotalSpent { get; set; }
    }
}
