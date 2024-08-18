using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class Room : BaseModel
    {
        public string name { get; set; }
        public Status Status { get; set; }
        public int? FeedbackId { get; set; }
        public Feedback? Feedback { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public List<Pictures>? Pictures { get; set; }
        [JsonIgnore]
        public List<Facilities>? Facilities { get; set; }


    }

    public enum Status
    {
        Available,
        pending,
        Reserved
        
    }

    public enum Types
    {
       
        singleRoom,
        DoubleRoom,

    }
}
