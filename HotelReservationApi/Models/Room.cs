using HotelReservationApi.Constant.Enum;


namespace HotelReservationApi.Models
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
        public double Price { get; set; }

        public List<Offer> Offers { get; set; }
        public List<Picture>? Pictures { get; set; }
        public List<RoomFacility> RoomFacilities { get; set; }
        public List<RoomReservation> RoomReservations { get; set; }
    }
}

