using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationApi.Models
{
    public class RoomFacility : BaseModel
    {
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [ForeignKey("Facilities")]

        public int FacilityId { get;set; }
        public Facility Facilities { get; set; }
    
    }
}
