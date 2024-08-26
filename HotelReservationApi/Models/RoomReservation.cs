﻿using HotelReservationApi.Constant.Enum;

namespace HotelReservationApi.Models
{
    public class RoomReservation:BaseModel
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int FacilityId { get; set; }
        public Facility Facilities { get; set; }
    }
}
