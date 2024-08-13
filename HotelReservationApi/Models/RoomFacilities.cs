namespace HotelReservationApi.Models
{
    public class RoomFacilities : BaseModel
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int FacilityId { get;set; }
        public Facilities Facilities { get; set; }
    
    }
}
