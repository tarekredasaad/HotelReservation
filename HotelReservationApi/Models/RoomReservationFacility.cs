namespace HotelReservationApi.Models
{
    public class RoomReservationFacility : BaseModel
    {
        public int RoomReservationId { get; set; }
        public RoomReservation RoomReservation { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set;}

    }
}
