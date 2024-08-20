namespace HotelReservationApi.DTOs.Rooms
{
    public class RoomReservationDTO
    {
        public HashSet<int> RoomIds { get; set; }
        public int ReservationId { get; set; }
    }
}
