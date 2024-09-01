﻿namespace HotelReservationApi.Models
{
    public class Customer : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Feedback> Feedbacks {  get; set; }  
    }
}
