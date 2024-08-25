namespace HotelReservationApi.ViewModels.RoomReservations
{
    public class RoomReservationCreateViewModel
    {
        public int RoomId { get; set; }
        public List<int> FacilityIDs { get; set; }
    }
}
