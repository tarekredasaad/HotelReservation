using HotelReservationApi.Constant.Enum;
using HotelReservationApi.Models;
using HotelReservationApi.ViewModels.RoomReservations;

namespace HotelReservationApi.ViewModels.Reservations
{
    public class ReservationCreateViewModel
    {
        //public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public List<RoomReservationCreateViewModel> RoomReservations { get; set; }
    }
}
