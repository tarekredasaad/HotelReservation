namespace HotelReservationApi.Models
{
    public class Picture : BaseModel
    {
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public string name { get; set; }
        public string? ContentType { get; set; }

        public byte[] Data { get; set; }

        //public string? Url { get; set; }

        //public string? File_Path { get; set; }

        //public byte[] Content { get; set; }
    }
}
