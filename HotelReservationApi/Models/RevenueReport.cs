namespace HotelReservationApi.Models
{
    public class RevenueReport : BaseModel
    {
        public DateTime Date { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
