namespace HotelReservationApi.Models
{
    public class Room : BaseModel
    {
        public string name { get; set; }
        public Status Status { get; set; }
        public int FeedbackId { get; set; }
        public Feedback Feedback { get; set; }
        public Type Type { get; set; }
        public double Price { get; set; }
        
        public List<Pictures> Pictures { get; set; }

        public List<Facilities> Facilities { get; set; }


    }

    public enum Status
    {
        Available,
        pending,
        Reserved
        
    }

    public enum Type
    {
        Sweat,
        singleRoom,
        DoubleRoom,

    }
}
