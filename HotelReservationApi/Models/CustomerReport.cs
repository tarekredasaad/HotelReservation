namespace HotelReservationApi.Models
{
    public class CustomerReport : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalReservation { get; set; }
        public decimal TotalSpent { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
