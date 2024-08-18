namespace HotelReservationApi.Models
{
    public class Facilities:BaseModel
    {
        public string name { get; set; }
        public double Cost { get; set; }
        public List<Room> rooms { get; set; }
    }
}
