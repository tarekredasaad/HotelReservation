namespace HotelReservationApi.ViewModels.Reports
{
    public class CustomerReportViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalReservations { get; set; }
        public double TotalSpent { get; set; }
    }
}
