namespace HotelReservationApi.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int GroupId {  get; set; }
        public Group Group { get; set; }
    }
}
