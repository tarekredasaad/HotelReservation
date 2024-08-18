using HotelReservationApi.Constant.Enum;
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
       
        public List<RoomFacility> RoomFacilities { get; set; }

        public List<RoomOffer> RoomOffers { get; set; }

        
    }

   
    
}

