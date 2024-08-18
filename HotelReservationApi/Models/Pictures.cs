﻿namespace HotelReservationApi.Models
{
    public class Pictures :BaseModel
    {
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public string name { get; set; }
        public string? ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
