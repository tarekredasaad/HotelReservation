namespace HotelReservationApi.DTOs.RoomReservationDTO
{
    public class CreateRoomReservationDTO
    {
        public HashSet<int> RoomIds { get; set; }
        public int ReservationId { get; set; }
    }
}
