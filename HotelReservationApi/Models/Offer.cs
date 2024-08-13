namespace HotelReservationApi.Models
{
    public class Offer :BaseModel
    {
       
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        public string Name { get; set; }
        public double Discount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Room> Rooms { get; set; }
        
    }
}
