using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.ViewModels.RoomFacilities;

namespace HotelReservationApi.ViewModels.Reservations
{
    public class ReservationViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public HashSet<ReservationFacilityViewModel> ReservationFacilities { get; set; }
 
    }
}
