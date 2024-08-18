using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class Facility:BaseModel
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        [JsonIgnore]
        public List<RoomFacility> RoomFacilities { get; set; }
    }
}
