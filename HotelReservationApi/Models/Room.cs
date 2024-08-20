using HotelReservationApi.Constant.Enum;
using System.Text.Json.Serialization;


namespace HotelReservationApi.Models
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public int? FeedbackId { get; set; }
        public Feedback? Feedback { get; set; }
        public Types Type { get; set; }
        public double Price { get; set; }

        public List<Offer> Offers { get; set; }
        public List<Picture>? Pictures { get; set; }
        public List<RoomFacility> RoomFacilities { get; set; }
        public List<RoomReservation> RoomReservations { get; set; }
    }
}

