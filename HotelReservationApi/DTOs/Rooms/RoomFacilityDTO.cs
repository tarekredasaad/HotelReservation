namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomFacilityDTO
    {
        public int RoomId { get; set; }
        public HashSet<int> FacilityId { get; set; }
    }
}
