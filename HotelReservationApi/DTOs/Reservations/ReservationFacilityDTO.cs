namespace HotelReservationApi.DTOs.Reservations
{
    public class ReservationFacilityDTO
    {
        public int RoomId { get; set; }
        public List<int> FacilitiesIDs { get; set; }
    }
}
