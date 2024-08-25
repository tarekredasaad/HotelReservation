using HotelReservationApi.Constant.Enum;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.RoomReservations;

namespace HotelReservationApi.ViewModels.Reservations
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public double TotalAmount { get; set; }

        public List<RoomReservationViewModel> RoomReservations { get; set; }
    }
}
