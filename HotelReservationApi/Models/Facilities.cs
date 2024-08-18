using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class Facilities:BaseModel
    {
        public string name { get; set; }
        public double Cost { get; set; }
        [JsonIgnore]
        public List<Room> rooms { get; set; }
    }
}
