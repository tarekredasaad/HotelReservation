using HotelReservationApi.ViewModels.Facilities;

namespace HotelReservationApi.ViewModels.RoomReservations
{
    public class RoomReservationViewModel
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
        public List<FacilityViewModel> Facilities { get; set; }
    }
}
