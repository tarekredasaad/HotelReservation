namespace HotelReservationApi.ViewModels.Reservations
{
    public class ReservationFacilityViewModel
    {
        public int RoomId { get; set; }
        public HashSet<int> FacilitiesIDs { get; set; }
    }
}
