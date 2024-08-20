namespace HotelReservationApi.DTOs.RoomReservationDTO
{
    public class RoomReservationDTO
    {
        public HashSet<int> Rooms { get; set; }
        public int ReservationId { get; set; } 
        public double Totalprice {  get; set; }
        public bool IsReserved => true;
        public int NumberDays { get; set; }
    }
}
