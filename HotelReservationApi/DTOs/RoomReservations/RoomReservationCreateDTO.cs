namespace HotelReservationApi.DTOs.RoomReservations
{
    public class RoomReservationCreateDTO
    {
        public int RoomId { get; set; }
        public List<int> FacilityIDs { get; set; }
    }
}
