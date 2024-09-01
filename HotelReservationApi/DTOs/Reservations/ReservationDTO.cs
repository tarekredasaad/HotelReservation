using HotelReservationApi.Constant.Enum;
using HotelReservationApi.DTOs.RoomReservations;
using HotelReservationApi.ViewModels.RoomReservations;

namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
       
        public HashSet<RoomFacilityDTO> ReservationFacilities { get; set; }
        
    }
}
