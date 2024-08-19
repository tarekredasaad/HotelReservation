namespace HotelReservationApi.DTOs.RoomReservationDTO
{
    public class RoomReservationDTO
    {
        public HashSet<int> RoomIds { get; set; }
        public int ReservationId { get; set; }  
    }
}
