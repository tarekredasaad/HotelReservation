﻿using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.ViewModels.RoomReservations;

namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string PaymentIntentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double TotalAmount { get; set; }

        public List<RoomReservationDTO> RoomReservations { get; set; }
    }
}
