namespace HotelReservationApi.Models
{
    public class Staff : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
