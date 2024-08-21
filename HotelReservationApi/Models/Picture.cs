namespace HotelReservationApi.Models
{
    public class Picture : BaseModel
    {
        public string Name { get; set; }
        public string URL { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
