﻿namespace HotelReservationApi.Models
{
    public class RoomReservation:BaseModel
    {
        public int RoomId { get; set; } 
        public Room Room { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int NumberDays { get; set; }
        public double TotalPrice { get; set; }


    }
}