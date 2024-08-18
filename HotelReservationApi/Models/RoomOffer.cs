namespace HotelReservationApi.Models
{
    public class RoomOffer : BaseModel
    {
        public int OfferId { get; set; }
        public Offer offer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }


    }
}
