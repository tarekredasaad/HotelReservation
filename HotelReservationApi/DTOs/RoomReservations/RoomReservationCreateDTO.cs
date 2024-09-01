namespace HotelReservationApi.DTOs.RoomReservations
{
    public class RoomReservationCreateDTO
    {
        public HashSet<int> RoomIds { get; set; }
        public int ReservationId { get; set; }
    }
}