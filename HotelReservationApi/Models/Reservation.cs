using HotelReservationApi.Constant.Enum;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class Reservation :BaseModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public bool IsConfirmed { get; set; } = false;
        public int NumberDays { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public double TotalPrice { get; set; }

        [JsonIgnore]
        public List<RoomReservation> RoomReservations { get; set; }
    }
}
