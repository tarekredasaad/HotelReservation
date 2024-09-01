using HotelReservationApi.DTOs;
using HotelReservationApi.DTOs.Rooms;
using HotelReservationApi.ViewModel.RoomFacilities;

namespace HotelReservationApi.ViewModel.Reservations
{
    public class ReservationViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public HashSet<ReservationFacilityViewModel> ReservationFacilities { get; set; }
 
    }
}
